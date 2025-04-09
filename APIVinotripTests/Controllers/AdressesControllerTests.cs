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
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(adresses);

            
            var actionResult = await controller.GetAdresses();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAdresses_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Adresse>());

            
            var actionResult = await controller.GetAdresses();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAdresseById_ExistingId_ReturnsAdresse()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(adresses[0]);

            
            var actionResult = await controller.GetAdresseById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(adresses[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetAdresseById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(99));

            
            var actionResult = await controller.GetAdresseById(99);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetAdresseByTitle_ExistingTitle_ReturnsAdresse()
        {
            
            
            mockRepository.Setup(x => x.GetByString("Destination Name")).ReturnsAsync(adresses[0]);

            
            var actionResult = await controller.GetAdresseByTitle("Destination Name");

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(adresses[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetAdresseByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetByString("NonExisting"));

            
            var actionResult = await controller.GetAdresseByTitle("NonExisting");

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostAdresse_ValidModel_CreatesAdresse()
        {
            
            mockRepository.Setup(x => x.Add(adresse)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostAdresse(adresse);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Adresse));
            Assert.AreEqual(adresse, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutAdresse_ValidUpdate_ReturnsNoContent()
        {
            
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

            
            var actionResult = await controller.PutAdresse(1, updatedAdresse);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutAdresse_IdMismatch_ReturnsBadRequest()
        {
            
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

            
            var actionResult = await controller.PutAdresse(999, updatedAdresse);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteAdresse_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(adresse);
            mockRepository.Setup(x => x.Delete(adresse)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteAdresse(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteAdresse_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(99));

            
            var actionResult = await controller.DeleteAdresse(99);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
