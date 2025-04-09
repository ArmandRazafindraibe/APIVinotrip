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
    public class DureeControllerTests
    {
        private Mock<IDataRepository<Duree>> mockRepository;
        private DureeController controller;
        private Duree duree;
        private List<Duree> durees;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IDataRepository<Duree>>();
            controller = new DureeController(mockRepository.Object);
            duree = new Duree
            {
                IdDuree = 1,
                LibelleDuree = "2 jours"
            };

            durees = new List<Duree>
            {
                new Duree
                {
                    IdDuree = 1,
                    LibelleDuree = "2 jours"
                },
                new Duree
                {
                    IdDuree = 2,
                    LibelleDuree = "1 semaine"
                }
            };
        }

        [TestMethod]
        public async Task GetDurees_ReturnsListOfDurees()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(durees);

           
            var actionResult = await controller.GetDurees();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(2, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetDurees_EmptyList_ReturnsEmpty()
        {
            
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Duree>());

           
            var actionResult = await controller.GetDurees();

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(0, actionResult.Value.Count());
        }

        [TestMethod]
        public async Task GetDureeById_ExistingId_ReturnsDuree()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(durees[0]);

           
            var actionResult = await controller.GetDureeById(1);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(durees[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetDureeById_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

           
            var actionResult = await controller.GetDureeById(999);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetDureeByTitle_ExistingTitle_ReturnsDuree()
        {
            
            string title = "2 jours";
            mockRepository.Setup(x => x.GetByString(title)).ReturnsAsync(durees[0]);

           
            var actionResult = await controller.GetDureeByTitle(title);

            
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(durees[0], actionResult.Value);
        }

        [TestMethod]
        public async Task GetDureeByTitle_UnknownTitle_ReturnsNotFound()
        {
            
            string title = "Durée inconnue";
            mockRepository.Setup(x => x.GetByString(title));

           
            var actionResult = await controller.GetDureeByTitle(title);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostDuree_ValidModel_CreatesDuree()
        {
            
            mockRepository.Setup(x => x.Add(duree)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.PostDuree(duree);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));
            var createdAtResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(createdAtResult.Value, typeof(Duree));
            Assert.AreEqual(duree, createdAtResult.Value);
        }

        [TestMethod]
        public async Task PostDuree_InvalidModel_ReturnsBadRequest()
        {
            
            controller.ModelState.AddModelError("LibelleDuree", "Le libellé est requis");

           
            var actionResult = await controller.PostDuree(duree);

            
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutDuree_ValidUpdate_ReturnsNoContent()
        {
            
            var updatedDuree = new Duree
            {
                IdDuree = 1,
                LibelleDuree = "3 jours"
            };
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(duree);
            mockRepository.Setup(x => x.Update(duree, updatedDuree)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.PutDuree(1, updatedDuree);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PutDuree_IdMismatch_ReturnsBadRequest()
        {
            
            var updatedDuree = new Duree { IdDuree = 2 };

           
            var actionResult = await controller.PutDuree(1, updatedDuree);

            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutDuree_UnknownId_ReturnsNoContent()
        {
            
            var updatedDuree = new Duree { IdDuree = 999 };
            mockRepository.Setup(x => x.GetById(999)).ReturnsAsync((Duree)null);

           
            var actionResult = await controller.PutDuree(999, updatedDuree);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteDuree_ExistingId_ReturnsNoContent()
        {
            
            mockRepository.Setup(x => x.GetById(1)).ReturnsAsync(duree);
            mockRepository.Setup(x => x.Delete(duree)).Returns(Task.CompletedTask);

           
            var actionResult = await controller.DeleteDuree(1);

            
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteDuree_UnknownId_ReturnsNotFound()
        {
            
            mockRepository.Setup(x => x.GetById(999));

           
            var actionResult = await controller.DeleteDuree(999);

            
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}