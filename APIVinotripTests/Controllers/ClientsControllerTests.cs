using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVinotrip.Tests
{
    [TestClass]
    public class ClientsControllerTests
    {
        private Mock<IDataRepository<Client>> mockRepository;
        private ClientsController controller;
        private Client client;
        private List<Client> clients;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Client>>();
            controller = new ClientsController(mockRepository.Object);

            client = new Client
            {
                IdClient = 1,
                EmailClient = "test@example.com",
                PrenomClient = "John",
                NomClient = "Doe",
                CiviliteClient = "M",
                DateNaissanceClient = new DateTime(1990, 1, 1),
                MdpClient = "secret",
                offresPromotionnellesClient = true,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = false,
                TelClient = "1234567890",
                TokenResetMDP = "token",
                DateCreationToken = DateTime.Now
            };

            clients = new List<Client>
            {
                client,
                new Client
                {
                    IdClient = 2,
                    EmailClient = "jane@example.com",
                    PrenomClient = "Jane",
                    NomClient = "Smith",
                    CiviliteClient = "Mme",
                    DateNaissanceClient = new DateTime(1985, 5, 5),
                    MdpClient = "password",
                    offresPromotionnellesClient = false,
                    DateDerniereActiviteClient = DateTime.Now,
                    A2f = true,
                    TelClient = "0987654321",
                    TokenResetMDP = "token2",
                    DateCreationToken = DateTime.Now
                }
            };
        }

        [TestMethod]
        public void GetUserData_ReturnsUserResponse()
        {
            // Act
            var result = controller.GetUserData();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("This is a response from user method", okResult.Value);
        }

        [TestMethod]
        public void GetAdminData_ReturnsAdminResponse()
        {
            // Act
            var result = controller.GetAdminData();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual("This is a response from Admin method", okResult.Value);
        }

        [TestMethod]
        public async Task GetClients_ReturnsListOfClients()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(clients);

            // Act
            var actionResult = await controller.GetClients();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetClientById_ExistingId_ReturnsClient()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(client);

            // Act
            var actionResult = await controller.GetClientById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(client, actionResult.Value);
        }

        [TestMethod]
        public async Task GetClientById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.GetClientById(999);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetClientByEmail_ExistingEmail_ReturnsClient()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("test@example.com")).ReturnsAsync(client);

            // Act
            var actionResult = await controller.GetClientByEmail("test@example.com");

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(client, actionResult.Value);
        }

        [TestMethod]
        public async Task GetClientByEmail_UnknownEmail_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("unknown@example.com"));

            // Act
            var actionResult = await controller.GetClientByEmail("unknown@example.com");

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PutClient_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedClient = new Client
            {
                IdClient = 1,
                EmailClient = "updated@example.com",
                PrenomClient = "JohnUpdated",
                NomClient = "DoeUpdated",
                CiviliteClient = "M",
                DateNaissanceClient = new DateTime(1990, 1, 1),
                MdpClient = "newsecret",
                offresPromotionnellesClient = false,
                DateDerniereActiviteClient = DateTime.Now,
                A2f = true,
                TelClient = "111222333",
                TokenResetMDP = "newtoken",
                DateCreationToken = DateTime.Now
            };

            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(client);
            mockRepository.Setup(x => x.Update(client, updatedClient)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutClient(1, updatedClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutClient_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var updatedClient = new Client
            {
                IdClient = 1,
                EmailClient = "updated@example.com",
                PrenomClient = "JohnUpdated",
                NomClient = "DoeUpdated"
            };

            // Act
            var actionResult = await controller.PutClient(999, updatedClient);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteClient_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(client);
            mockRepository.Setup(x => x.Delete(client)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteClient(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteClient_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.DeleteClient(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostClient_ValidModel_CreatesClient()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(client)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostClient(client);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Client));
            Assert.AreEqual(client, createdAtResult.Value);
        }
    }
}
