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
    public class CategoriesSejourControllerTests
    {
        private Mock<IDataRepository<CategorieSejour>> mockRepository;
        private CategoriesSejourController controller;
        private CategorieSejour categorieSejour;
        private List<CategorieSejour> categoriesSejour;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<CategorieSejour>>();
            controller = new CategoriesSejourController(mockRepository.Object);
            categorieSejour = new CategorieSejour
            {
                IdCategorieSejour = 1,
                LibelleCategoriesSejour = "Dégustation"
            };

            categoriesSejour = new List<CategorieSejour>
            {
                new CategorieSejour
                {
                    IdCategorieSejour = 1,
                    LibelleCategoriesSejour = "Dégustation"
                },
                new CategorieSejour
                {
                    IdCategorieSejour = 2,
                    LibelleCategoriesSejour = "Découverte"
                }
            };
        }

        [TestMethod]
        public async Task GetCategorieSejours_ReturnsListOfCategories()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(categoriesSejour);

            
            var actionResult = await controller.GetCategorieSejours();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieSejours_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CategorieSejour>());

            
            var actionResult = await controller.GetCategorieSejours();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieSejourById_ExistingId_ReturnsCategorie()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categoriesSejour[0]);

            
            var actionResult = await controller.GetCategorieSejourById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categoriesSejour[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieSejourById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.GetCategorieSejourById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetCategorieSejourByTitle_ExistingTitle_ReturnsCategorie()
        {
            
            string title = "Dégustation";
            mockRepository.Setup(x => x.GetByString(title)).ReturnsAsync(categoriesSejour[0]);

            
            var actionResult = await controller.GetCategorieSejourByTitle(title);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categoriesSejour[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieSejourByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            string title = "Catégorie inconnue";
            mockRepository.Setup(x => x.GetByString(title));

            
            var actionResult = await controller.GetCategorieSejourByTitle(title);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostCategorieSejour_ValidModel_CreatesCategorie()
        {
            
            mockRepository.Setup(x => x.Add(categorieSejour)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PostCategorieSejour(categorieSejour);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(CategorieSejour));
            Assert.AreEqual(categorieSejour, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostCategorieSejour_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("LibelleCategoriesSejour", "Le libellé est requis");

            
            var actionResult = await controller.PostCategorieSejour(categorieSejour);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutCategorieSejour_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedCategorieSejour = new CategorieSejour
            {
                IdCategorieSejour = 1,
                LibelleCategoriesSejour = "Prestige"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorieSejour);
            mockRepository.Setup(x => x.Update(categorieSejour, updatedCategorieSejour)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.PutCategorieSejour(1, updatedCategorieSejour);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutCategorieSejour_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedCategorieSejour = new CategorieSejour { IdCategorieSejour = 2 };

            
            var actionResult = await controller.PutCategorieSejour(1, updatedCategorieSejour);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutCategorieSejour_UnknownId_ReturnsNotFound()
        {
            
            var updatedCategorieSejour = new CategorieSejour { IdCategorieSejour = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((CategorieSejour)null);

            
            var actionResult = await controller.PutCategorieSejour(999, updatedCategorieSejour);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCategorieSejour_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorieSejour);
            mockRepository.Setup(x => x.Delete(categorieSejour)).Returns(Task.CompletedTask);

            
            var actionResult = await controller.DeleteCategorieSejour(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCategorieSejour_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

            
            var actionResult = await controller.DeleteCategorieSejour(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}