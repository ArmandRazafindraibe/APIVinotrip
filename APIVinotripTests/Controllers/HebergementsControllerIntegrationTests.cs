using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;

namespace APIVinotrip.Tests
{
    [TestClass()]
    public class HebergementsControllerIntegrationTests
    {
        private HebergementsController _controller;
        private DBVinotripContext _context;
        private IDataRepository<Hebergement> _repository;
        private List<int> _hebergementsToCleanup; // Liste pour suivre les hébergements à nettoyer

        [TestInitialize]
        public void Initialize()
        {
            // Configuration de la connexion à la base de données
            var builder = new DbContextOptionsBuilder<DBVinotripContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip;uid=postgres;password=postgres");
            _context = new DBVinotripContext(builder.Options);

            // Créer un repository pour les hébergements
            _repository = new HebergementManager(_context);

            // Créer le contrôleur avec les dépendances
            _controller = new HebergementsController(_repository);

            // Initialiser la liste des hébergements à nettoyer
            _hebergementsToCleanup = new List<int>();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Nettoyer tous les hébergements créés pendant les tests
            foreach (var hebergementId in _hebergementsToCleanup)
            {
                try
                {
                    var hebergement = await _context.Hebergements.FindAsync(hebergementId);
                    if (hebergement != null)
                    {
                        _context.Hebergements.Remove(hebergement);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors du nettoyage de l'hébergement {hebergementId}: {ex.Message}");
                }
            }

            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
        }

        [TestMethod()]
        public async Task GetHebergements_ReturnsAllHebergements()
        {
            // Act
            var result = await _controller.GetHebergements();

            // Assert
            var actionResult = result as ActionResult<IEnumerable<Hebergement>>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<Hebergement>>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.IsTrue(actionResult.Value.Any(), "Aucun hébergement trouvé");
        }

        [TestMethod()]
        public async Task GetHebergementById_ExistingId_ReturnsHebergement()
        {
            // Arrange - Trouver un hébergement existant dans la base
            var existingHebergement = await _context.Hebergements.FirstOrDefaultAsync();
            Assert.IsNotNull(existingHebergement, "Aucun hébergement trouvé dans la base de données pour le test");
            int hebergementId = existingHebergement.IdHebergement;

            // Act
            var result = await _controller.GetHebergementById(hebergementId);

            // Assert
            var actionResult = result as ActionResult<Hebergement>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Hebergement>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(hebergementId, actionResult.Value.IdHebergement, "IDs d'hébergement différents");
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetHebergementById_UnknownId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.GetHebergementById(99999);

            // Assert
            var actionResult = result as ActionResult<Hebergement>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Hebergement>), "Pas ActionResult");
            
            Assert.AreEqual(((NotFoundResult)actionResult.Result).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]  
        public async Task DeleteHebergement_UnknownId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.DeleteHebergement(99999);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "Pas NotFoundResult");
            Assert.AreEqual(((NotFoundResult)actionResult).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod()]
        public async Task PutHebergement_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            // Trouver un hébergement existant à mettre à jour
            var existingHebergement = await _context.Hebergements.FirstOrDefaultAsync();
            Assert.IsNotNull(existingHebergement, "Aucun hébergement trouvé dans la base de données pour le test");

            int hebergementId = existingHebergement.IdHebergement;
            int partenaireId = existingHebergement.IdPartenaire;
  

            // Créer une version mise à jour de l'hébergement existant
            Hebergement updatedHebergement = new Hebergement
            {
                IdHebergement = hebergementId,
                IdPartenaire = partenaireId,
                DescriptionHebergement = "Description mise à jour pour test",
                PhotoHebergement = existingHebergement.PhotoHebergement,
                LienHebergement = existingHebergement.LienHebergement,
                PrixHebergement = existingHebergement.PrixHebergement
            };

            // Act
            var result = await _controller.PutHebergement(hebergementId, updatedHebergement);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 204");

            // Vérifier que l'hébergement a bien été mis à jour
            var hebergementFromDb = await _context.Hebergements.FindAsync(hebergementId);
            Assert.AreEqual("Description mise à jour pour test", hebergementFromDb.DescriptionHebergement, "La description n'a pas été mise à jour");
        }

        [TestMethod()]
        public async Task PutHebergement_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            Hebergement updatedHebergement = new Hebergement
            {
                IdHebergement = 7777,
                DescriptionHebergement = "Description mise à jour"
            };

            // Act
            var result = await _controller.PutHebergement(6666, updatedHebergement);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((BadRequestResult)actionResult).StatusCode, StatusCodes.Status400BadRequest, "Pas 400");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task PutHebergement_UnknownId_ReturnsNotFound()
        {
            // Arrange
            Hebergement updatedHebergement = new Hebergement
            {
                IdHebergement = 99999,
                DescriptionHebergement = "Description d'un hébergement inexistant"
            };

            // Act
            var result = await _controller.PutHebergement(99999, updatedHebergement);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult), "Pas NotFoundResult");
            Assert.AreEqual(((NotFoundResult)actionResult).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod()]
        public async Task PostHebergement_ValidHebergement_ReturnsCreatedAtAction()
        {
            // Arrange
            // Trouver un hébergement existant pour copier ses propriétés
            var existingHebergement = await _context.Hebergements.FirstOrDefaultAsync();
            Assert.IsNotNull(existingHebergement, "Aucun hébergement trouvé dans la base de données pour le test");

            // Utiliser un ID qui ne risque pas de conflit avec les hébergements existants
            Hebergement newHebergement = new Hebergement
            {
                IdHebergement = await _context.Hebergements.MaxAsync(h => h.IdHebergement) + 1000, // ID élevé pour éviter les conflits
                IdPartenaire = existingHebergement.IdPartenaire,
                DescriptionHebergement = "Nouvel hébergement pour test d'intégration",
                PhotoHebergement = existingHebergement.PhotoHebergement,
                LienHebergement = existingHebergement.LienHebergement,
                PrixHebergement = existingHebergement.PrixHebergement
            };

            // Act
            var result = await _controller.PostHebergement(newHebergement);

            // Assert
            var actionResult = result as ActionResult<Hebergement>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Hebergement>), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas CreatedAtActionResult");

            var createdAtActionResult = (CreatedAtActionResult)actionResult.Result;
            Assert.AreEqual("GetById", createdAtActionResult.ActionName, "Mauvais nom d'action");

            // Ajouter l'hébergement à la liste de nettoyage
            _hebergementsToCleanup.Add(newHebergement.IdHebergement);
        }

        [TestMethod()]
        public async Task PostHebergement_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            Hebergement invalidHebergement = new Hebergement();
            _controller.ModelState.AddModelError("PrixHebergement", "Le prix est requis");

            // Act
            var result = await _controller.PostHebergement(invalidHebergement);

            // Assert
            var actionResult = result as ActionResult<Hebergement>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Hebergement>), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult), "Pas BadRequestObjectResult");
            Assert.AreEqual(((BadRequestObjectResult)actionResult.Result).StatusCode, StatusCodes.Status400BadRequest, "Pas 400");
        }
    }
}