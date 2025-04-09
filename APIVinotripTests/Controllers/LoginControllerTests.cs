using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using APIVinotrip.Helpers;
using System.Linq;

namespace APIVinotrip.Tests
{
    [TestClass]
    public class LoginControllerTests
    {
        private Mock<IDataRepository<Client>> mockRepository;
        private Mock<IConfiguration> mockConfiguration;
        private LoginController controller;
        private Client validClient;
        private Client invalidClient;
        private List<Client> clientList;

        [TestInitialize]
        public void Setup()
        {
            // Setup mock repository
            mockRepository = new Mock<IDataRepository<Client>>();

            // Setup mock configuration for JWT
            mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["Jwt:SecretKey"]).Returns("ThisIsAVeryLongSecretKeyForTestingPurposesOnly12345678901234");
            mockConfiguration.Setup(x => x["Jwt:Issuer"]).Returns("VinotripTestIssuer");
            mockConfiguration.Setup(x => x["Jwt:Audience"]).Returns("VinotripTestAudience");

            // Create controller with mocks
            controller = new LoginController(mockConfiguration.Object, mockRepository.Object);

            // Create a hashed password for testing
            string hashedPassword = PasswordHasher.HashPassword("TestPassword123");

            // Setup client data
            validClient = new Client
            {
                IdClient = 1,
                IdRole = 1,
                CiviliteClient = "M.",
                PrenomClient = "Jean",
                NomClient = "Dupont",
                EmailClient = "jean.dupont@example.com",
                DateNaissanceClient = new DateTime(1985, 5, 15),
                MdpClient = hashedPassword,
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "0123456789"
            };

            clientList = new List<Client>
            {
                validClient,
                new Client
                {
                    IdClient = 2,
                    IdRole = 1,
                    CiviliteClient = "Mme",
                    PrenomClient = "Marie",
                    NomClient = "Durand",
                    EmailClient = "marie.durand@example.com",
                    DateNaissanceClient = new DateTime(1990, 10, 20),
                    MdpClient = PasswordHasher.HashPassword("AnotherPassword456"),
                    offresPromotionnellesClient = false,
                    DateDerniereActiviteClient = DateTime.Now.AddDays(-5),
                    A2f = false,
                    TelClient = "0987654321"
                }
            };

            // Setup invalid client with wrong credentials
            invalidClient = new Client
            {
                EmailClient = "jean.dupont@example.com",
                MdpClient = "WrongPassword"
            };
        }

        [TestMethod]
        public async Task Login_ValidCredentials_ReturnsOkWithToken()
        {
            // Arrange
            var loginClient = new Client
            {
                EmailClient = "jean.dupont@example.com",
                MdpClient = "TestPassword123"
            };
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clientList);

            // Act
            var actionResult = await controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            var okResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Value);

            // Check if the result contains token and userDetails
            var resultObject = okResult.Value.GetType().GetProperties();
            Assert.IsTrue(resultObject.Any(p => p.Name == "token"));
            Assert.IsTrue(resultObject.Any(p => p.Name == "userDetails"));

            // Ensure password is not returned
            var userDetailsProperty = resultObject.First(p => p.Name == "userDetails");
            var userDetails = userDetailsProperty.GetValue(okResult.Value) as Client;
            Assert.IsNull(userDetails.MdpClient);
        }

        [TestMethod]
        public async Task Login_InvalidPassword_ReturnsUnauthorized()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clientList);

            // Act
            var actionResult = await controller.Login(invalidClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public async Task Login_NonExistentEmail_ReturnsUnauthorized()
        {
            // Arrange
            var nonExistentClient = new Client
            {
                EmailClient = "nonexistent@example.com",
                MdpClient = "TestPassword123"
            };
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clientList);

            // Act
            var actionResult = await controller.Login(nonExistentClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public async Task Login_ValidPhoneCredentials_ReturnsOkWithToken()
        {
            // Arrange
            var loginClient = new Client
            {
                TelClient = "0123456789",
                MdpClient = "TestPassword123"
            };
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clientList);

            // Act
            var actionResult = await controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Login_NullEmail_HandlesGracefully()
        {
            // Arrange
            var loginClient = new Client
            {
                EmailClient = null,
                MdpClient = "TestPassword123"
            };
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clientList);

            // Act
            var actionResult = await controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }

        [TestMethod]
        public async Task Login_EmptyClientList_ReturnsUnauthorized()
        {
            // Arrange
            var loginClient = new Client
            {
                EmailClient = "jean.dupont@example.com",
                MdpClient = "TestPassword123"
            };
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Client>());

            // Act
            var actionResult = await controller.Login(loginClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(UnauthorizedResult));
        }
    }
}