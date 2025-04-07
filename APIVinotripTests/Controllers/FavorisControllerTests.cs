using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIVinotrip.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers.Tests
{
    [TestClass()]
    public class FavorisControllerTests
    {
        private Mock<IDataRepository<Favoris>> mockRepository;
        private FavorisController controller;
        private Favoris favoris;
        private List<Favoris> mesFavoris;

        [TestInitialize]
        public void Setup()
        {
            mesFavoris = new List<Favoris>
            {
                new Favoris { IdClient = 1, IdSejour = 100 },
                new Favoris { IdClient = 2, IdSejour = 200 }
            };
            favoris = new Favoris
            {
                IdClient = 1,
                IdSejour = 100
            };
        }


        [TestMethod]
        public async Task GetFavoris_ReturnsListOfFavoris()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(mesFavoris);

            // Act
            var actionResult = await controller.GetFavoris();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetFavoris_EmptyList_ReturnsEmpty()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Favoris>());

            // Act
            var actionResult = await controller.GetFavoris();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetFavorisById_ExistingId_ReturnsRoute()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(mesFavoris[0]);

            // Act
            var actionResult = await controller.GetFavorisById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(mesFavoris[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetFavorisById_UnknownId_ReturnsNotFound()
        {

            // Arrange
            mockRepository.Setup(x => x.GetById(929));

            // Act
            var actionResult = await controller.GetFavorisById(929);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        //[TestMethod]
        //public async Task GetFavorisByTitle_ExistingTitle_ReturnsRoute()
        //{
        //    // Arrange
        //    mockRepository.Setup(x => x.GetByString("Route des Grands Crus")).ReturnsAsync(mesFavoris[0]);

        //    // Act
        //    var actionResult = await controller.GetFavorisByIdSejour("Route des Grands Crus");

        //    // Assert
        //    Assert.IsNotNull(actionResult.Value);
        //    Assert.AreEqual(mesFavoris[0], actionResult.Value);
        //}

        //[TestMethod]
        //public async Task GetFavorisByTitle_UnknownTitle_ReturnsNotFound()
        //{
        //    // Arrange
        //    mockRepository.Setup(x => x.GetByString("Unknown"));

        //    // Act
        //    var actionResult = await controller.GetFavorisByTitle("Unknown");

        //    // Assert
        //    Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        //}

        [TestMethod]
        public async Task PostFavoris_ValidModel_CreatesRoute()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(favoris)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostFavoris(favoris);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Favoris));
            Assert.AreEqual(favoris, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutFavoris_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedRoute = new Favoris
            {
                IdSejour = 1,
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(favoris);
            mockRepository.Setup(x => x.Update(favoris, updatedRoute)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutFavoris(1, updatedRoute);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutFavoris_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((Favoris)null);

            // Act
            var actionResult = await controller.PutFavoris(999, favoris);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteFavoris_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(favoris);
            mockRepository.Setup(x => x.Delete(favoris)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteFavoris(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteFavoris_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(99));

            // Act
            var actionResult = await controller.DeleteFavoris(99);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}