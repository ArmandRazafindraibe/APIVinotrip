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
    public class AvisControllerTests
    {
        private Mock<IDataRepository<Avis>> mockRepository;
        private AvisController controller;
        private Avis avis;
        private List<Avis> avisList;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Avis>>();
            controller = new AvisController(mockRepository.Object);

            
            avis = new Avis
            {
                IdAvis = 1,
                DateAvis = new DateTime(2023, 3, 26),
                TitreAvis = "Great Stay",
                DescriptionAvis = "I had a wonderful stay",
                NoteAvis = 5,
                PhotoAvis = "photo.jpg",
                IdSejour = 10,
                IdClient = 100
            };

            avisList = new List<Avis>
            {
                avis,
                new Avis
                {
                    IdAvis = 2,
                    DateAvis = new DateTime(2023, 3, 27),
                    TitreAvis = "Average",
                    DescriptionAvis = "It was okay",
                    NoteAvis = 3,
                    PhotoAvis = "photo2.jpg",
                    IdSejour = 11,
                    IdClient = 101
                }
            };
        }

        [TestMethod]
        public async Task GetAvis_ReturnsListOfAvis()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(avisList);

            // Act
            var actionResult = await controller.GetAvis();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAvis_EmptyList_ReturnsEmpty()
        {
            // Arrange
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Avis>());

            // Act
            var actionResult = await controller.GetAvis();

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetAvisById_ExistingId_ReturnsAvis()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(avis);

            // Act
            var actionResult = await controller.GetAvisById(1);

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(avis, actionResult.Value);
        }

        [TestMethod]
        public async Task GetAvisById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.GetAvisById(999);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetAvisByTitle_ExistingTitle_ReturnsAvis()
        {
            // Arrange
            
            mockRepository.Setup(x => x.GetByString("Great Stay")).ReturnsAsync(avis);

            // Act
            var actionResult = await controller.GetAvisByTitle("Great Stay");

            // Assert
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(avis, actionResult.Value);
        }

        [TestMethod]
        public async Task GetAvisByTitle_UnknownTitle_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetByString("Nonexistent"));

            // Act
            var actionResult = await controller.GetAvisByTitle("Nonexistent");

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostAvis_ValidModel_CreatesAvis()
        {
            // Arrange
            mockRepository.Setup(x => x.Add(avis)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PostAvis(avis);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdAtResult);
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Avis));
            Assert.AreEqual(avis, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutAvis_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            var updatedAvis = new Avis
            {
                IdAvis = 1,
                DateAvis = new DateTime(2023, 3, 28),
                TitreAvis = "Updated Title",
                DescriptionAvis = "Updated description",
                NoteAvis = 4,
                PhotoAvis = "updatedPhoto.jpg",
                IdSejour = 10,
                IdClient = 100
            };

            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(avis);
            mockRepository.Setup(x => x.Update(avis, updatedAvis)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.PutAvis(1, updatedAvis);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutAvis_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            var updatedAvis = new Avis
            {
                IdAvis = 1,
                DateAvis = new DateTime(2023, 3, 28),
                TitreAvis = "Updated Title",
                DescriptionAvis = "Updated description",
                NoteAvis = 4,
                PhotoAvis = "updatedPhoto.jpg",
                IdSejour = 10,
                IdClient = 100
            };

            // Act
            var actionResult = await controller.PutAvis(999, updatedAvis);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteAvis_ExistingId_ReturnsNoContent()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(avis);
            mockRepository.Setup(x => x.Delete(avis)).Returns(Task.CompletedTask);

            // Act
            var actionResult = await controller.DeleteAvis(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteAvis_UnknownId_ReturnsNotFound()
        {
            // Arrange
            mockRepository.Setup(x => x.GetById(999));

            // Act
            var actionResult = await controller.DeleteAvis(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
