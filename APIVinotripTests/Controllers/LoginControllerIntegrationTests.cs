using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;
using Microsoft.Extensions.Configuration;
using APIVinotrip.Helpers;

namespace APIVinotrip.Tests
{
    [TestClass()]
    public class LoginControllerIntegrationTests
    {
        private LoginController _controller;
        private DBVinotripContext _context;
        private IDataRepository<Client> _repository;
        private IConfiguration _configuration;
        private List<int> _clientsToCleanup; // Liste pour suivre les clients à nettoyer

        [TestInitialize]
        public void Initialize()
        {
            // Configuration de la connexion à la base de données
            var builder = new DbContextOptionsBuilder<DBVinotripContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip;uid=postgres;password=postgres");
            _context = new DBVinotripContext(builder.Options);

            // Créer un repository pour les clients
            _repository = new ClientManager(_context);

            // Configuration pour JWT
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:SecretKey", "ThisIsAVeryLongSecretKeyForAPIVinotripTesting12345678901234"},
                {"Jwt:Issuer", "VinotripIssuer"},
                {"Jwt:Audience", "VinotripAudience"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            // Créer le contrôleur avec les dépendances
            _controller = new LoginController(_configuration, _repository);

            // Initialiser la liste des clients à nettoyer
            _clientsToCleanup = new List<int>();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Nettoyer tous les clients créés pendant les tests
            foreach (var clientId in _clientsToCleanup)
            {
                try
                {
                    var client = await _context.Clients.FindAsync(clientId);
                    if (client != null)
                    {
                        _context.Clients.Remove(client);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors du nettoyage du client {clientId}: {ex.Message}");
                }
            }

            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
        }

        [TestMethod()]
        public async Task Login_ValidCredentials_ReturnsOkWithToken()
        {
            // Arrange
            // Créer un client temporaire pour le test
            string password = "TestPassword123";
            string hashedPassword = PasswordHasher.HashPassword(password);

            Client testClient = new Client
            {
                // Utiliser un ID élevé pour éviter les conflits
                IdClient = 9999,
                IdRole = 1,
                CiviliteClient = "M.",
                PrenomClient = "Test",
                NomClient = "User",
                EmailClient = "test.user@example.com",
                DateNaissanceClient = new DateTime(1990, 1, 1),
                MdpClient = hashedPassword,
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "0123456789"
            };

            // Ajouter le client à la base de données
            await _context.Clients.AddAsync(testClient);
            await _context.SaveChangesAsync();
            _clientsToCleanup.Add(9999); // Ajouter à la liste de nettoyage

            // Créer des identifiants valides pour la connexion
            var loginClient = new Client
            {
                EmailClient = "test.user@example.com",
                MdpClient = "TestPassword123"
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Résultat n'est pas OkObjectResult");
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult, "OkObjectResult est null");
            Assert.IsNotNull(okResult.Value, "Valeur est nulle");


        }

        [TestMethod()]
        public async Task Login_InvalidPassword_ReturnsUnauthorized()
        {
            // Arrange
            // Créer un client temporaire pour le test
            string password = "CorrectPassword123";
            string hashedPassword = PasswordHasher.HashPassword(password);

            Client testClient = new Client
            {
                IdClient = 8888,
                IdRole = 1,
                CiviliteClient = "Mme",
                PrenomClient = "Wrong",
                NomClient = "Password",
                EmailClient = "wrong.password@example.com",
                DateNaissanceClient = new DateTime(1985, 5, 15),
                MdpClient = hashedPassword,
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "0987654321"
            };

            // Ajouter le client à la base de données
            await _context.Clients.AddAsync(testClient);
            await _context.SaveChangesAsync();
            _clientsToCleanup.Add(8888); // Ajouter à la liste de nettoyage

            // Créer des identifiants avec un mot de passe incorrect
            var loginClient = new Client
            {
                EmailClient = "wrong.password@example.com",
                MdpClient = "WrongPassword123"
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult), "Résultat n'est pas UnauthorizedResult");
        }

        [TestMethod()]
        public async Task Login_NonExistentEmail_ReturnsUnauthorized()
        {
            // Arrange
            // Créer des identifiants avec un email inexistant
            var loginClient = new Client
            {
                EmailClient = "nonexistent@example.com",
                MdpClient = "SomePassword123"
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult), "Résultat n'est pas UnauthorizedResult");
        }

        [TestMethod()]
        public async Task Login_ValidPhoneCredentials_ReturnsOkWithToken()
        {
            // Arrange
            // Créer un client temporaire avec un numéro de téléphone unique
            string password = "PhonePassword123";
            string hashedPassword = PasswordHasher.HashPassword(password);

            Client testClient = new Client
            {
                IdClient = 7777,
                IdRole = 1,
                CiviliteClient = "M.",
                PrenomClient = "Phone",
                NomClient = "User",
                EmailClient = "phone.user@example.com",
                DateNaissanceClient = new DateTime(1988, 8, 8),
                MdpClient = hashedPassword,
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "9876543210" // Numéro unique pour le test
            };

            // Ajouter le client à la base de données
            await _context.Clients.AddAsync(testClient);
            await _context.SaveChangesAsync();
            _clientsToCleanup.Add(7777); // Ajouter à la liste de nettoyage

            // Créer des identifiants avec le numéro de téléphone
            var loginClient = new Client
            {
                TelClient = "9876543210",
                MdpClient = "PhonePassword123"
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Résultat n'est pas OkObjectResult");
        }

        [TestMethod()]
        public async Task Login_NullEmail_HandlesGracefully()
        {
            // Arrange
            // Créer des identifiants avec un email null
            var loginClient = new Client
            {
                EmailClient = null,
                MdpClient = "SomePassword123"
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult), "Résultat n'est pas UnauthorizedResult");
        }

        [TestMethod()]
        public async Task Login_EmptyCredentials_ReturnsUnauthorized()
        {
            // Arrange
            // Créer des identifiants vides
            var loginClient = new Client
            {
                EmailClient = "",
                MdpClient = ""
            };

            // Act
            var result = await _controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedResult), "Résultat n'est pas UnauthorizedResult");
        }
    }
}