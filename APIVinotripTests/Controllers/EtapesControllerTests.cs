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
    public class EtapesControllerTests
    {
        private Mock<IEtapeRepository<Etape>> mockRepository;
        private EtapesController controller;
        private Etape etape;
        private List<Etape> etapes;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IEtapeRepository<Etape>>();
            controller = new EtapesController(mockRepository.Object);
            etape = new Etape
            {
                IdEtape = 1,
                IdSejour = 1,
                IdHebergement = 1,
                TitreEtape = "Visite du château",
                DescriptionEtape = "Une visite guidée du château viticole...",
                PhotoEtape = "chateau.jpg",
                URLEtape = "https://example.com/chateau",
                VideoEtape = "chateau.mp4"
            };

            etapes = new List<Etape>
            {
                new Etape
                {
                    IdEtape = 1,
                    IdSejour = 1,
                    IdHebergement = 1,
                    TitreEtape = "Visite du château",
                    DescriptionEtape = "Une visite guidée du château viticole...",
                    PhotoEtape = "chateau.jpg",
                    URLEtape = "https://example.com/chateau",
                    VideoEtape = "chateau.mp4"
                },
                new Etape
                {
                    IdEtape = 2,
                    IdSejour = 1,
                    IdHebergement = 2,
                    TitreEtape = "Dégustation de vin",
                    DescriptionEtape = "Une dégustation des vins de la région...",
                    PhotoEtape = "degustation.jpg",
                    URLEtape = "https://example.com/degustation",
                    VideoEtape = "degustation.mp4"
                }
            };
        }

        [TestMethod]
        public async Task GetEtapes_ReturnsListOfEtapes()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(etapes);

            
            var actionResult = await controller.GetEtapes();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetEtapes_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Etape>());

            
            var actionResult = await controller.GetEtapes();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetEtapeById_ExistingId_ReturnsEtape()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(etapes[0]);

            
            var actionResult = await controller.GetEtapeById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(etapes[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetEtapeById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.GetEtapeById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetEtapeByState_ExistingState_ReturnsEtape()
        {
            
            string etat = "active";
            mockRepository.Setup(x => x.GetByString(etat)).ReturnsAsync(etapes[0]);

            
            var actionResult = await controller.GetEtapeByState(etat);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(etapes[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetEtapeByState_UnknownState_ReturnsNotFound()
        {
            
            string etat = "inconnue";
            mockRepository.Setup(x => x.GetByString(etat));

            
            var actionResult = await controller.GetEtapeByState(etat);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostEtape_ValidModel_CreatesEtape()
        {
            
            mockRepository.Setup(x => x.Add(etape)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostEtape(etape);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Etape));
            Assert.AreEqual(etape, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostEtape_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("TitreEtape", "Le titre est requis");

            
            var actionResult = await controller.PostEtape(etape);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutEtape_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedEtape = new Etape
            {
                IdEtape = 1,
                IdSejour = 1,
                IdHebergement = 1,
                TitreEtape = "Visite du domaine viticole",
                DescriptionEtape = "Une visite exclusive du domaine...",
                PhotoEtape = "domaine.jpg",
                URLEtape = "https://example.com/domaine",
                VideoEtape = "domaine.mp4"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(etape);
            mockRepository.Setup(x => x.Update(etape, updatedEtape)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PutEtape(1, updatedEtape);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutEtape_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedEtape = new Etape { IdEtape = 2 };

            
            var actionResult = await controller.PutEtape(1, updatedEtape);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutEtape_UnknownId_ReturnsNoContent()
        {
            
            var updatedEtape = new Etape { IdEtape = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((Etape)null);

            
            var actionResult = await controller.PutEtape(999, updatedEtape);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteEtape_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(etape);
            mockRepository.Setup(x => x.Delete(etape)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteEtape(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteEtape_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.DeleteEtape(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}