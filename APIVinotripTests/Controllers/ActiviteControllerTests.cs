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
    public class ActivitesControllerTests
    {
        private Mock<IDataRepository<Activite>> mockRepository;
        private ActivitesController controller;
        private Activite activite;
        private List<Activite> activites;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Activite>>();
            controller = new ActivitesController(mockRepository.Object);

            
            activite = new Activite
            {
                IdActivite = 1,
                LibelleActivite = "Mountain Biking",
                PrixActivite = 99.99m
            };

            activites = new List<Activite>
            {
                activite,
                new Activite
                {
                    IdActivite = 2,
                    LibelleActivite = "Kayaking",
                    PrixActivite = 79.99m
                }
            };
        }

        [TestMethod]
        public async Task GetActivites_ReturnsListOfActivites()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(activites);

            
            var result = await controller.GetActivites();

            
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(2, result.Value.Count());
        }

        [TestMethod]
        public async Task GetActivites_EmptyList_ReturnsEmptyList()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Activite>());

            
            var result = await controller.GetActivites();

            
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(0, result.Value.Count());
        }

        [TestMethod]
        public async Task GetActiviteById_ExistingId_ReturnsActivite()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(activite);

            
            var result = await controller.GetActiviteById(1);

            
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(activite, result.Value);
        }

        [TestMethod]
        public async Task GetActiviteById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var result = await controller.GetActiviteById(999);

            
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetActiviteByTitle_ExistingTitle_ReturnsActivite()
        {
            
            // Предполагаем, что поиск осуществляется по свойству LibelleActivite
            mockRepository.Setup(x => x.GetByString("Mountain Biking")).ReturnsAsync(activite);

            
            var result = await controller.GetActiviteByTitle("Mountain Biking");

            
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(activite, result.Value);
        }

        [TestMethod]
        public async Task GetActiviteByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetByString("Unknown"));

            
            var result = await controller.GetActiviteByTitle("Unknown");

            
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostActivite_ValidModel_CreatesActivite()
        {
            
            mockRepository.Setup(x => x.Add(activite)).Returns(Task.CompletedTask);

            
            var result = await controller.PostActivite(activite);

            
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            var createdResult = result.Result as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);
            Assert.IsInstanceOfType(createdResult.Value, typeof(Activite));
            Assert.AreEqual(activite, createdResult.Value);
        }

        [TestMethod]
        public async Task PutActivite_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedActivite = new Activite
            {
                IdActivite = 1,
                LibelleActivite = "Updated Mountain Biking",
                PrixActivite = 109.99m
            };

            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(activite);
            mockRepository.Setup(x => x.Update(activite, updatedActivite)).Returns(Task.CompletedTask);

            
            var result = await controller.PutActivite(1, updatedActivite);

            
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutActivite_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedActivite = new Activite
            {
                IdActivite = 1,
                LibelleActivite = "Updated Mountain Biking",
                PrixActivite = 109.99m
            };

            
            var result = await controller.PutActivite(999, updatedActivite);

            
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteActivite_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(activite);
            mockRepository.Setup(x => x.Delete(activite)).Returns(Task.CompletedTask);

            
            var result = await controller.DeleteActivite(1);

            
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteActivite_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var result = await controller.DeleteActivite(999);

            
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
