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
    public class CategoriesParticipantControllerTests
    {
        private Mock<IDataRepository<CategorieParticipant>> mockRepository;
        private CategoriesParticipantController controller;
        private CategorieParticipant categorieParticipant;
        private List<CategorieParticipant> categoriesParticipant;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<CategorieParticipant>>();
            controller = new CategoriesParticipantController(mockRepository.Object);
            categorieParticipant = new CategorieParticipant
            {
                IdCategorieParticipant = 1,
                LibelleCategorieParticipant = "Adulte"
            };

            categoriesParticipant = new List<CategorieParticipant>
            {
                new CategorieParticipant
                {
                    IdCategorieParticipant = 1,
                    LibelleCategorieParticipant = "Adulte"
                },
                new CategorieParticipant
                {
                    IdCategorieParticipant = 2,
                    LibelleCategorieParticipant = "Enfant"
                }
            };
        }

        [TestMethod]
        public async Task GetCategorieParticipants_ReturnsListOfCategories()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(categoriesParticipant);

           
            var actionResult = await controller.GetCategorieParticipants();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieParticipants_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<CategorieParticipant>());

           
            var actionResult = await controller.GetCategorieParticipants();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetCategorieParticipantById_ExistingId_ReturnsCategorie()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categoriesParticipant[0]);

           
            var actionResult = await controller.GetCategorieParticipantById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categoriesParticipant[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieParticipantById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

           
            var actionResult = await controller.GetCategorieParticipantById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetCategorieParticipantByTitle_ExistingTitle_ReturnsCategorie()
        {
            
            string title = "Adulte";
            mockRepository.Setup(x => x.GetByString(title)).ReturnsAsync(categoriesParticipant[0]);

           
            var actionResult = await controller.GetCategorieParticipantByTitle(title);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(categoriesParticipant[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetCategorieParticipantByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            string title = "Catégorie inconnue";
            mockRepository.Setup(x => x.GetByString(title));

           
            var actionResult = await controller.GetCategorieParticipantByTitle(title);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostCategorieParticipant_ValidModel_CreatesCategorie()
        {
            
            mockRepository.Setup(x => x.Add(categorieParticipant)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.PostCategorieParticipant(categorieParticipant);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(CategorieParticipant));
            Assert.AreEqual(categorieParticipant, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostCategorieParticipant_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("LibelleCategorieParticipant", "Le libellé est requis");

           
            var actionResult = await controller.PostCategorieParticipant(categorieParticipant);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutCategorieParticipant_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedCategorieParticipant = new CategorieParticipant
            {
                IdCategorieParticipant = 1,
                LibelleCategorieParticipant = "Senior"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorieParticipant);
            mockRepository.Setup(x => x.Update(categorieParticipant, updatedCategorieParticipant)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.PutCategorieParticipant(1, updatedCategorieParticipant);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutCategorieParticipant_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedCategorieParticipant = new CategorieParticipant { IdCategorieParticipant = 2 };

           
            var actionResult = await controller.PutCategorieParticipant(1, updatedCategorieParticipant);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutCategorieParticipant_UnknownId_ReturnsNoContent()
        {
            
            var updatedCategorieParticipant = new CategorieParticipant { IdCategorieParticipant = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((CategorieParticipant)null);

           
            var actionResult = await controller.PutCategorieParticipant(999, updatedCategorieParticipant);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCategorieParticipant_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(categorieParticipant);
            mockRepository.Setup(x => x.Delete(categorieParticipant)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.DeleteCategorieParticipant(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteCategorieParticipant_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

           
            var actionResult = await controller.DeleteCategorieParticipant(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}