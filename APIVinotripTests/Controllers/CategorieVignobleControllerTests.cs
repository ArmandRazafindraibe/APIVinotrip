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
    public class CategorieVignobleControllerTests
    {
        private Mock<IDataRepository<CategorieVignoble>> mockRepository;
        private CategorieVignobleController controller;
        private CategorieVignoble categorie;
        private List<CategorieVignoble> categories;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<CategorieVignoble>>();
            controller = new CategorieVignobleController(mockRepository.Object);

            
            categorie = new CategorieVignoble
            {
                IdCategorieVignoble = 1,
                LibelleCategorieVignoble = "Rouge"
            };

            categories = new List<CategorieVignoble>
            {
                categorie,
                new CategorieVignoble
                {
                    IdCategorieVignoble = 2,
                    LibelleCategorieVignoble = "Blanc"
                }
            };
        }

        [TestMethod]
        public async Task GetCategorieVignobles_ReturnsListOfCategories()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(categories);

            
            var actionResult = await controller.GetCategorieVignobles();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieVignobles_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CategorieVignoble>());

            
            var actionResult = await controller.GetCategorieVignobles();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieVignobleById_ExistingId_ReturnsCategorie()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categories[0]);

            
            var actionResult = await controller.GetCategorieVignobleById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categories[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieVignobleById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.GetCategorieVignobleById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetCategorieVignobleByTitle_ExistingTitle_ReturnsCategorie()
        {
            
            mockRepository.Setup(x => x.GetByString("Rouge")).ReturnsAsync(categories[0]);

            
            var actionResult = await controller.GetCategorieVignobleByTitle("Rouge");

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categories[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieVignobleByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetByString("Inconnu"));

            
            var actionResult = await controller.GetCategorieVignobleByTitle("Inconnu");

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostCategorieVignoble_ValidModel_CreatesCategorie()
        {
            
            mockRepository.Setup(x => x.Add(categorie)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostCategorieVignoble(categorie);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(CategorieVignoble));
            Assert.AreEqual(categorie, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PutCategorieVignoble_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedCategorie = new CategorieVignoble
            {
                IdCategorieVignoble = 1,
                LibelleCategorieVignoble = "Rosé"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorie);
            mockRepository.Setup(x => x.Update(categorie, updatedCategorie)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PutCategorieVignoble(1, updatedCategorie);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutCategorieVignoble_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedCategorie = new CategorieVignoble
            {
                IdCategorieVignoble = 1,
                LibelleCategorieVignoble = "Rosé"
            };

            
            var actionResult = await controller.PutCategorieVignoble(999, updatedCategorie);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteCategorieVignoble_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorie);
            mockRepository.Setup(x => x.Delete(categorie)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteCategorieVignoble(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCategorieVignoble_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.DeleteCategorieVignoble(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
