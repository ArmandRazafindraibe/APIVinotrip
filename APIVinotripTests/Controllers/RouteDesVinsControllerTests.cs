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
    public class RouteDesVinsControllerTests
    {
        private Mock<IDataRepository<RouteDesVins>> mockRepository;
        private RouteDesVinsController controller;
        private RouteDesVins route;
        private List<RouteDesVins> routes;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<RouteDesVins>>();
            controller = new RouteDesVinsController(mockRepository.Object);
            route = new RouteDesVins
            {
                IdRoute = 1,
                LibRoute = "Route des Grands Crus",
                DescriptionRoute = "Une magnifique route des vins...",
                PhotoRoute = "photo.jpg"
            };

            routes = new List<RouteDesVins>
            {
                new RouteDesVins
                {
                    IdRoute = 1,
                    LibRoute = "Route des Grands Crus",
                    DescriptionRoute = "Une magnifique route des vins...",
                    PhotoRoute = "photo1.jpg"
                },
                new RouteDesVins
                {
                    IdRoute = 2,
                    LibRoute = "Route des Vins d'Alsace",
                    DescriptionRoute = "Une route à travers les vignobles alsaciens...",
                    PhotoRoute = "photo2.jpg"
                }
            };
        }

        [TestMethod]
        public async Task GetRouteDesVins_ReturnsListOfRoutes()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(routes);

            // Act
            var actionResult = await controller.GetRouteDesVins();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2,actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetRouteDesVins_EmptyList_ReturnsEmpty()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<RouteDesVins>());

            // Act
            var actionResult = await controller.GetRouteDesVins();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetRouteDesVinsById_ExistingId_ReturnsRoute()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(routes[0]);

            // Act
            var actionResult = await controller.GetRouteDesVinsById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(routes[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetRouteDesVinsById_UnknownId_ReturnsNotFound()
        {
            
            // Arrange
            mockRepository.Setup(x => x.GetById(929));

            // Act
            var actionResult = await controller.GetRouteDesVinsById(929);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetRouteDesVinsByTitle_ExistingTitle_ReturnsRoute()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("Route des Grands Crus")).ReturnsAsync(routes[0]);

            // Act
            var actionResult = await controller.GetRouteDesVinsByTitle("Route des Grands Crus");

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(routes[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetRouteDesVinsByTitle_UnknownTitle_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("Unknown"));

            // Act
            var actionResult = await controller.GetRouteDesVinsByTitle("Unknown");

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostRouteDesVins_ValidModel_CreatesRoute()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(route)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostRouteDesVins(route);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(RouteDesVins));
            Assert.AreEqual(route, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutRouteDesVins_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedRoute = new RouteDesVins
            {
                IdRoute = 1,
                LibRoute = "Nouvelle Route",
                DescriptionRoute = "Une autre belle route",
                PhotoRoute = "nouvellephoto.jpg"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(route);
            mockRepository.Setup(x => x.Update(route, updatedRoute)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutRouteDesVins(1, updatedRoute);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutRouteDesVins_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((RouteDesVins)null);

            // Act
            var actionResult = await controller.PutRouteDesVins(999, route);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteRouteDesVins_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(route);
            mockRepository.Setup(x => x.Delete(route)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteRouteDesVins(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteRouteDesVins_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(99));

            // Act
            var actionResult = await controller.DeleteRouteDesVins(99);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
