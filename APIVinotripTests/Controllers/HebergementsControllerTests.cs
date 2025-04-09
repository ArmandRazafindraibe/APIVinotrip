using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIVinotrip.Tests
{
    [TestClass]
    public class HebergementsControllerTests
    {
        private Mock<IDataRepository<Hebergement>> mockRepository;
        private HebergementsController controller;
        private Hebergement hebergement;
        private List<Hebergement> hebergements;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Hebergement>>();
            controller = new HebergementsController(mockRepository.Object);
            hebergement = new Hebergement
            {
                IdHebergement = 1,
                IdPartenaire = 1,
                DescriptionHebergement = "Un magnifique hébergement...",
                PhotoHebergement = "photo.jpg",
                LienHebergement = "https://example.com/hebergement1",
                PrixHebergement = 150.50m
            };

            hebergements = new List<Hebergement>
            {
                new Hebergement
                {
                    IdHebergement = 1,
                    IdPartenaire = 1,
                    DescriptionHebergement = "Un magnifique hébergement...",
                    PhotoHebergement = "photo1.jpg",
                    LienHebergement = "https://example.com/hebergement1",
                    PrixHebergement = 150.50m
                },
                new Hebergement
                {
                    IdHebergement = 2,
                    IdPartenaire = 2,
                    DescriptionHebergement = "Un autre hébergement luxueux...",
                    PhotoHebergement = "photo2.jpg",
                    LienHebergement = "https://example.com/hebergement2",
                    PrixHebergement = 200.75m
                }
            };
        }

        [TestMethod]
        public async Task GetHebergements_ReturnsListOfHebergements()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(hebergements);

            
            var actionResult = await controller.GetHebergements();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetHebergements_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Hebergement>());

            
            var actionResult = await controller.GetHebergements();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetHebergementById_ExistingId_ReturnsHebergement()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(hebergements[0]);

            
            var actionResult = await controller.GetHebergementById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(hebergements[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetHebergementById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.GetHebergementById(999);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetHebergementByState_ExistingState_ReturnsHebergement()
        {
            
            string etat = "disponible";
            mockRepository.Setup(x => x.GetByString(etat)).ReturnsAsync(hebergements[0]);

            
            var actionResult = await controller.GetHebergementByState(etat);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(hebergements[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetHebergementByState_UnknownState_ReturnsNotFound()
        {
            
            string etat = "inconnu";
            mockRepository.Setup(x => x.GetByString(etat));

            
            var actionResult = await controller.GetHebergementByState(etat);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostHebergement_ValidModel_CreatesHebergement()
        {
            
            mockRepository.Setup(x => x.Add(hebergement)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostHebergement(hebergement);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Hebergement));
            Assert.AreEqual(hebergement, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostHebergement_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("PrixHebergement", "Le prix est requis");

            
            var actionResult = await controller.PostHebergement(hebergement);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutHebergement_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedHebergement = new Hebergement
            {
                IdHebergement = 1,
                IdPartenaire = 1,
                DescriptionHebergement = "Description mise à jour",
                PhotoHebergement = "nouvelle_photo.jpg",
                LienHebergement = "https://example.com/updated",
                PrixHebergement = 180.00m
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(hebergement);
            mockRepository.Setup(x => x.Update(hebergement, updatedHebergement)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PutHebergement(1, updatedHebergement);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutHebergement_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedHebergement = new Hebergement { IdHebergement = 2 };

            
            var actionResult = await controller.PutHebergement(1, updatedHebergement);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutHebergement_UnknownId_ReturnsNotFound()
        {
            
            var updatedHebergement = new Hebergement { IdHebergement = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((Hebergement)null);

            
            var actionResult = await controller.PutHebergement(999, updatedHebergement);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteHebergement_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(hebergement);
            mockRepository.Setup(x => x.Delete(hebergement)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteHebergement(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteHebergement_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.DeleteHebergement(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}