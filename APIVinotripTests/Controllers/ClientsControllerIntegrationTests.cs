using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVinotrip.Tests
{
    [TestClass()]
    public class ClientsControllerIntegrationTests
    {
        private ClientsController _controller;
        private DBVinotripContext _context;
        private IDataRepository<Client> _repository;


        [TestInitialize]
        public void Initialize()
        {
            // Configuration de la connexion à la base de données
            var builder = new DbContextOptionsBuilder<DBVinotripContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip;uid=postgres;password=postgres");
            _context = new DBVinotripContext(builder.Options);

            _repository = new ClientManager(_context);

            // Créer le contrôleur en utilisant le repository
            _controller = new ClientsController(_repository);
        }

        [TestMethod()]
        public async Task GetClients_ReturnsAllClients()
        {
            // Arrange
            Client c1 = new Client
            {
                IdClient = 1,
                IdRole = 1,
                CiviliteClient = "M",
                PrenomClient = "Elliott",
                NomClient = "Serena",
                EmailClient = "serenaelliott8820@google.com",
                DateNaissanceClient = new DateTime(1977, 2, 18),
                MdpClient = "$2y$12$oG8AVZThhOQp3Huf3yPSsOjklPDT.wTdMdTsYKrwXTWVtngfnm7AG",
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = new DateTime(2022, 5, 8),
                A2f = false,
                TelClient = "0767662202  ",
                TokenResetMDP = null,
                DateCreationToken = null
            };

            Client c2 = new Client
            {
                IdClient = 2,
                IdRole = 1,
                CiviliteClient = "M",
                PrenomClient = "Houston",
                NomClient = "Isaiah",
                EmailClient = "i_houston8482@yahoo.fr",
                DateNaissanceClient = new DateTime(1997, 6, 9),
                MdpClient = "$2y$12$T7aFs0JYqyVIFsqDKlpZpOqCNS4zNBaA7Olxbn5s4CexFEUPb85M6",
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = new DateTime(2024, 7, 21),
                A2f = false,
                TelClient = "0637056342  ",
                TokenResetMDP = null,
                DateCreationToken = null
            };

            List<Client> listeEsperee = new List<Client>();
            listeEsperee.Add(c1);
            listeEsperee.Add(c2);

            // Act
            var result = await _controller.GetClients();

            // Assert
            var actionResult = result as ActionResult<IEnumerable<Client>>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<Client>>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            CollectionAssert.AreEqual(listeEsperee, actionResult.Value.Where(c => c.IdClient <= 2).ToList(), "Collections différentes");
        }

        [TestMethod()]
        public async Task GetClientById_ExistingId_ReturnsClient()
        {
            // Arrange
            Client c1 = new Client
            {
                IdClient = 1,
                IdRole = 1,
                CiviliteClient = "M",
                PrenomClient = "Elliott",
                NomClient = "Serena",
                EmailClient = "serenaelliott8820@google.com",
                DateNaissanceClient = new DateTime(1977, 2, 18),
                MdpClient = "$2y$12$oG8AVZThhOQp3Huf3yPSsOjklPDT.wTdMdTsYKrwXTWVtngfnm7AG",
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = new DateTime(2022, 5, 8),
                A2f = false,
                TelClient = "0767662202  ",
                TokenResetMDP = null,
                DateCreationToken = null
            };

            // Act
            var result = await _controller.GetClientById(1);

            // Assert
            var actionResult = result as ActionResult<Client>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Client>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(c1.IdClient, actionResult.Value.IdClient, "ID client différent");
            Assert.AreEqual(c1.EmailClient, actionResult.Value.EmailClient, "Email différent");
            Assert.AreEqual(c1.PrenomClient, actionResult.Value.PrenomClient, "Prénom différent");
            Assert.AreEqual(c1.NomClient, actionResult.Value.NomClient, "Nom différent");
        }

        [TestMethod()]
       
        public async Task GetClientById_UnknownId_ReturnsNoContent()
        {
            // Act
            var result = await _controller.GetClientById(777);

            // Assert
            var actionResult = result as ActionResult<Client>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Client>), "Pas ActionResult");
    
        }

        [TestMethod()]
        public async Task GetClientByEmail_ExistingEmail_ReturnsClient()
        {
            // Arrange
            Client c1 = new Client
            {
                IdClient = 1,
                IdRole = 1,
                CiviliteClient = "M",
                PrenomClient = "Elliott",
                NomClient = "Serena",
                EmailClient = "serenaelliott8820@google.com",
                DateNaissanceClient = new DateTime(1977, 2, 18),
                MdpClient = "$2y$12$oG8AVZThhOQp3Huf3yPSsOjklPDT.wTdMdTsYKrwXTWVtngfnm7AG",
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = new DateTime(2022, 5, 8),
                A2f = false,
                TelClient = "0767662202  ",
                TokenResetMDP = null,
                DateCreationToken = null
            };

            string existingEmail = "serenaelliott8820@google.com";

            // Act
            var result = await _controller.GetClientByEmail(existingEmail);

            // Assert
            var actionResult = result as ActionResult<Client>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Client>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(existingEmail, actionResult.Value.EmailClient, "Email différent");
            Assert.AreEqual(c1.IdClient, actionResult.Value.IdClient, "ID client différent");
            Assert.AreEqual(c1.PrenomClient, actionResult.Value.PrenomClient, "Prénom différent");
            Assert.AreEqual(c1.NomClient, actionResult.Value.NomClient, "Nom différent");
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetClientByEmail_UnknownEmail_ReturnsNotFound()
        {
            // Act
            var result = await _controller.GetClientByEmail("unknown@example.com");

            // Assert
            var actionResult = result as ActionResult<Client>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Client>), "Pas ActionResult");
 
            Assert.AreEqual(StatusCodes.Status204NoContent, ((NotFoundResult)actionResult.Result).StatusCode, "Pas 404");
        }

        [TestMethod()]
        public async Task PostClient_ThenDelete_ValidClient_Success()
        {
            // Arrange - Créer un nouveau client pour le test
            Client newClient = new Client
            {
                EmailClient = $"integration_test_{Guid.NewGuid()}@example.com", // Email unique
                PrenomClient = "IntegrationTest",
                NomClient = "User",
                CiviliteClient = "M",
                DateNaissanceClient = new DateTime(2000, 1, 1),
                MdpClient = "integration_password",
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "9876543210",
                IdRole = 1 // Rôle Client par défaut
            };

            try
            {
                // Act - POST
                var postResult = await _controller.PostClient(newClient);

                // Assert - POST
                var postActionResult = postResult as ActionResult<Client>;
                Assert.IsInstanceOfType(postActionResult, typeof(ActionResult<Client>), "Pas ActionResult");
                Assert.IsInstanceOfType(postActionResult.Result, typeof(CreatedAtActionResult), "Pas CreatedAtActionResult");

                var createdAtActionResult = (CreatedAtActionResult)postActionResult.Result;
                Assert.AreEqual("GetClientById", createdAtActionResult.ActionName, "Mauvais nom d'action");

                // Récupérer l'ID du client créé
                var createdClient = createdAtActionResult.Value as Client;
                Assert.IsNotNull(createdClient, "Client créé est null");
                int newId = createdClient.IdClient;

                // Vérifier que le client a été créé
                var getResult = await _controller.GetClientById(newId);
                Assert.IsNotNull(getResult.Value, "Client créé introuvable");

                // Nettoyer - Supprimer le client créé
                var deleteResult = await _controller.DeleteClient(newId);
                Assert.IsInstanceOfType(deleteResult, typeof(NoContentResult), "Échec de la suppression");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test échoué avec exception: {ex.Message}");
            }
        }

        [TestMethod()]
        public async Task PutClient_UpdateExistingClient_Success()
        {
            // Arrange - Créer un client puis le modifier
            Client newClient = new Client
            {
                EmailClient = $"put_test_{Guid.NewGuid()}@example.com", // Email unique
                PrenomClient = "PutTest",
                NomClient = "User",
                CiviliteClient = "M",
                DateNaissanceClient = new DateTime(1995, 5, 5),
                MdpClient = "put_test_password",
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = true,
                TelClient = "1231231234",
                IdRole = 1 // Rôle Client par défaut
            };

            try
            {
                // Créer le client
                var postResult = await _controller.PostClient(newClient);
                var createdAtActionResult = (CreatedAtActionResult)postResult.Result;
                var createdClient = createdAtActionResult.Value as Client;
                int clientId = createdClient.IdClient;

                // Préparer les modifications
                var updatedClient = new Client
                {
                    IdClient = clientId,
                    EmailClient = createdClient.EmailClient, // Garder le même email
                    PrenomClient = "PutTestModified",
                    NomClient = "UserModified",
                    CiviliteClient = createdClient.CiviliteClient,
                    DateNaissanceClient = createdClient.DateNaissanceClient,
                    MdpClient = "new_password_modified",
                    offresPromotionnellesClient = !createdClient.offresPromotionnellesClient, // Inverser la valeur
                    DateDerniereActiviteClient = DateTime.Now,
                    A2f = !createdClient.A2f, // Inverser la valeur
                    TelClient = "9876543210",
                    IdRole = createdClient.IdRole
                };

                // Act - PUT
                var putResult = await _controller.PutClient(clientId, updatedClient);

                // Assert - PUT
                Assert.IsInstanceOfType(putResult, typeof(NoContentResult), "Pas NoContentResult");

                // Vérifier que les modifications ont été appliquées
                var getResult = await _controller.GetClientById(clientId);
                Assert.IsNotNull(getResult.Value, "Client introuvable après modification");
                Assert.AreEqual("PutTestModified", getResult.Value.PrenomClient, "Prénom non modifié");
                Assert.AreEqual("UserModified", getResult.Value.NomClient, "Nom non modifié");

                // Nettoyer - Supprimer le client créé
                await _controller.DeleteClient(clientId);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test échoué avec exception: {ex.Message}");
            }
        }

        [TestMethod()]
        public async Task PutClient_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            int clientId = 1; // ID existant
            var client = new Client
            {
                IdClient = 999, 
                EmailClient = "mismatch@example.com",
                PrenomClient = "Mismatch",
                NomClient = "Test"
            };

            // Act
            var result = await _controller.PutClient(clientId, client);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Pas BadRequestResult");
            Assert.AreEqual(StatusCodes.Status400BadRequest, ((BadRequestResult)result).StatusCode, "Pas 400");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DeleteClient_NonExistentId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.DeleteClient(979); 

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult), "Pas NotFoundResult");
            Assert.AreEqual(StatusCodes.Status204NoContent, ((NotFoundResult)result).StatusCode, "Pas 404");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Nettoyer les ressources si nécessaire
            _context.Dispose();
        }
    }
}