using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIVinotrip.Tests
{
    [TestClass]
    public class AdressesControllerTests
    {
        private Mock<IDataRepository<Adresse>> mockRepository;
        private AdressesController controller;
        private Adresse adresse;
        private List<Adresse> adresses;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Adresse>>();
            controller = new AdressesController(mockRepository.Object);

            
            adresse = new Adresse
            {
                IdAdresse = 1,
                NomAdresse = "Destination Name",
                PrenomAdresseDestination = "FirstName",
                RueAdresse = "Main Street",
                VilleAdresse = "CityName",
                PaysAdresse = "Country",
                CpAdresse = "12345",
                NumAdresse = "10"
            };

            adresses = new List<Adresse>
            {
                new Adresse
                {
                    IdAdresse = 1,
                    NomAdresse = "Destination Name",
                    PrenomAdresseDestination = "FirstName",
                    RueAdresse = "Main Street",
                    VilleAdresse = "CityName",
                    PaysAdresse = "Country",
                    CpAdresse = "12345",
                    NumAdresse = "10"
                },
                new Adresse
                {
                    IdAdresse = 2,
                    NomAdresse = "Another Destination",
                    PrenomAdresseDestination = "OtherName",
                    RueAdresse = "Second Street",
                    VilleAdresse = "OtherCity",
                    PaysAdresse = "OtherCountry",
                    CpAdresse = "54321",
                    NumAdresse = "20"
                }
            };
        }

        [TestMethod]
        public async Task GetAdresses_ReturnsListOfAdresses()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(adresses);

            // Act
            var actionResult = await controller.GetAdresses();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAdresses_EmptyList_ReturnsEmpty()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Adresse>());

            // Act
            var actionResult = await controller.GetAdresses();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAdresseById_ExistingId_ReturnsAdresse()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(adresses[0]);

            // Act
            var actionResult = await controller.GetAdresseById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(adresses[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetAdresseById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(99));

            // Act
            var actionResult = await controller.GetAdresseById(99);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetAdresseByTitle_ExistingTitle_ReturnsAdresse()
        {
            // Arrange
            
            mockRepository.Setup(x => x.GetByString("Destination Name")).ReturnsAsync(adresses[0]);

            // Act
            var actionResult = await controller.GetAdresseByTitle("Destination Name");

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(adresses[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetAdresseByTitle_UnknownTitle_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("NonExisting"));

            // Act
            var actionResult = await controller.GetAdresseByTitle("NonExisting");

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostAdresse_ValidModel_CreatesAdresse()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(adresse)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostAdresse(adresse);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Adresse));
            Assert.AreEqual(adresse, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutAdresse_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedAdresse = new Adresse
            {
                IdAdresse = 1,
                NomAdresse = "Updated Destination",
                PrenomAdresseDestination = "UpdatedName",
                RueAdresse = "Updated Street",
                VilleAdresse = "Updated City",
                PaysAdresse = "Updated Country",
                CpAdresse = "67890",
                NumAdresse = "30"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(adresse);
            mockRepository.Setup(x => x.Update(adresse, updatedAdresse)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutAdresse(1, updatedAdresse);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutAdresse_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var updatedAdresse = new Adresse
            {
                IdAdresse = 1,
                NomAdresse = "Updated Destination",
                PrenomAdresseDestination = "UpdatedName",
                RueAdresse = "Updated Street",
                VilleAdresse = "Updated City",
                PaysAdresse = "Updated Country",
                CpAdresse = "67890",
                NumAdresse = "30"
            };

            // Act
            var actionResult = await controller.PutAdresse(999, updatedAdresse);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteAdresse_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(adresse);
            mockRepository.Setup(x => x.Delete(adresse)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteAdresse(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteAdresse_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(99));

            // Act
            var actionResult = await controller.DeleteAdresse(99);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
