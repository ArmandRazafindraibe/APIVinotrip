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
    public class CommandesControllerTests
    {
        private Mock<IDataRepository<Commande>> mockRepository;
        private CommandesController controller;
        private Commande commande;
        private List<Commande> commandes;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Commande>>();
            controller = new CommandesController(mockRepository.Object);

            commande = new Commande
            {
                IdCommande = 1,
                IdCB = 123,
                IdAdresseFacturation = 10,
                IdClientAcheteur = 100,
                IdClientBeneficiaire = 200,
                IdAdresseLivraison = 20,
                IdPanier = 30,
                ValidationClient = true,
                codereduction = "PROMO20",
                EtatCommande = "Pending",
                TypePayementCommande = "CreditCard",
                DateCommande = new DateTime(2023, 03, 26)
            };

            commandes = new List<Commande>
            {
                commande,
                new Commande
                {
                    IdCommande = 2,
                    IdCB = 456,
                    IdAdresseFacturation = 11,
                    IdClientAcheteur = 101,
                    IdClientBeneficiaire = 201,
                    IdAdresseLivraison = 21,
                    IdPanier = 31,
                    ValidationClient = false,
                    codereduction = "PROMO10",
                    EtatCommande = "Completed",
                    TypePayementCommande = "Paypal",
                    DateCommande = new DateTime(2023, 03, 27)
                }
            };
        }

        [TestMethod]
        public async Task GetCommandes_ReturnsListOfCommandes()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(commandes);

            // Act
            var actionResult = await controller.GetCommandes();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCommandes_EmptyList_ReturnsEmpty()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Commande>());

            // Act
            var actionResult = await controller.GetCommandes();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCommandeById_ExistingId_ReturnsCommande()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(commande);

            // Act
            var actionResult = await controller.GetCommandeById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(commande, actionResult.Value);
        }

        [TestMethod]
        public async Task GetCommandeById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.GetCommandeById(999);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetCommandeByTitle_ExistingState_ReturnsCommande()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("Pending")).ReturnsAsync(commande);

            // Act
            var actionResult = await controller.GetCommandeByState("Pending");

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(commande, actionResult.Value);
        }

        [TestMethod]
        public async Task GetCommandeByTitle_UnknownState_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("Unknown"));

            // Act
            var actionResult = await controller.GetCommandeByState("Unknown");

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostCommande_ValidModel_CreatesCommande()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(commande)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostCommande(commande);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Commande));
            Assert.AreEqual(commande, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutCommande_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedCommande = new Commande
            {
                IdCommande = 1,
                IdCB = 789,
                IdAdresseFacturation = 15,
                IdClientAcheteur = 105,
                IdClientBeneficiaire = 205,
                IdAdresseLivraison = 25,
                IdPanier = 35,
                ValidationClient = false,
                codereduction = "PROMO50",
                EtatCommande = "Shipped",
                TypePayementCommande = "DebitCard",
                DateCommande = new DateTime(2023, 03, 28)
            };

            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(commande);
            mockRepository.Setup(x => x.Update(commande, updatedCommande)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutCommande(1, updatedCommande);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutCommande_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var updatedCommande = new Commande
            {
                IdCommande = 1,
                EtatCommande = "Shipped"
            };

            // Act
            var actionResult = await controller.PutCommande(999, updatedCommande);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteCommande_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(commande);
            mockRepository.Setup(x => x.Delete(commande)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteCommande(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCommande_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.DeleteCommande(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
