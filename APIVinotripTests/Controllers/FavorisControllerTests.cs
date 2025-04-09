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
    public class FavorisControllerTests
    {
        private Mock<IDataRepository<Favoris>> mockRepository;
        private FavorisController controller;
        private Favoris favoris;
        private List<Favoris> listeFavoris;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Favoris>>();
            controller = new FavorisController(mockRepository.Object);
            favoris = new Favoris
            {
                IdClient = 1,
                IdSejour = 1
            };

            listeFavoris = new List<Favoris>
            {
                new Favoris
                {
                    IdClient = 1,
                    IdSejour = 1
                },
                new Favoris
                {
                    IdClient = 1,
                    IdSejour = 2
                },
                new Favoris
                {
                    IdClient = 2,
                    IdSejour = 1
                }
            };
        }

        [TestMethod]
        public async Task GetFavoris_ReturnsListOfFavoris()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(listeFavoris);

            
            var actionResult = await controller.GetFavoris();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(3, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetFavoris_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Favoris>());

            
            var actionResult = await controller.GetFavoris();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetFavorisById_ExistingId_ReturnsFavoris()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(listeFavoris[0]);

            
            var actionResult = await controller.GetFavorisById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(listeFavoris[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetFavorisById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.GetFavorisById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetFavorisByIdClient_ExistingId_ReturnsFavoris()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(listeFavoris);

            
            var actionResult = await controller.GetFavorisByIdClient(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(1, actionResult.Value.IdClient);
        }

        [TestMethod]
        public async Task GetFavorisByIdClient_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(listeFavoris);

            
            var actionResult = await controller.GetFavorisByIdClient(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostFavoris_ValidModel_CreatesFavoris()
        {
            
            mockRepository.Setup(x => x.Add(favoris)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostFavoris(favoris);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Favoris));
            Assert.AreEqual(favoris, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostFavoris_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("IdClient", "L'ID client est requis");

            
            var actionResult = await controller.PostFavoris(favoris);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutFavoris_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedFavoris = new Favoris
            {
                IdClient = 2,
                IdSejour = 1
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(favoris);
            mockRepository.Setup(x => x.Update(favoris, updatedFavoris)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PutFavoris(1, updatedFavoris);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutFavoris_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedFavoris = new Favoris { IdSejour = 2 };

            
            var actionResult = await controller.PutFavoris(1, updatedFavoris);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutFavoris_UnknownId_ReturnsNotFound()
        {
            
            var updatedFavoris = new Favoris { IdSejour = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((Favoris)null);

            
            var actionResult = await controller.PutFavoris(999, updatedFavoris);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteFavoris_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(favoris);
            mockRepository.Setup(x => x.Delete(favoris)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteFavoris(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteFavoris_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.DeleteFavoris(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}