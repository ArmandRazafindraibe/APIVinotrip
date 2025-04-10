using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIVinotrip.Controllers;
using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIVinotrip.Models.Repository;
using APIVinotrip.Models.DataManager;
using System;

namespace APIVinotrip.Tests
{
    [TestClass()]
    public class RouteDesVinsControllerIntegrationTests
    {
        private RouteDesVinsController _controller;
        private DBVinotripContext _context;
        private IDataRepository<RouteDesVins> _repository;
        private List<int> _routesToCleanup; // Liste pour suivre les routes à nettoyer

        [TestInitialize]
        public void Initialize()
        {
            // Configuration de la connexion à la base de données
            var builder = new DbContextOptionsBuilder<DBVinotripContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip;uid=postgres;password=postgres");
            _context = new DBVinotripContext(builder.Options);

            _repository = new RouteDesVinsManager(_context);

            _controller = new RouteDesVinsController(_repository);

            // Initialiser la liste des routes à nettoyer
            _routesToCleanup = new List<int>();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Nettoyer toutes les routes créées pendant les tests
            foreach (var routeId in _routesToCleanup)
            {
                try
                {
                    var route = await _context.RouteDesVins.FindAsync(routeId);
                    if (route != null)
                    {
                        _context.RouteDesVins.Remove(route);
                    }
                }
                catch (Exception ex)
                {
                    // Logger l'exception ou l'ignorer si nécessaire
                    Console.WriteLine($"Erreur lors du nettoyage de la route {routeId}: {ex.Message}");
                }
            }

            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
        }

        [TestMethod()]
        public async Task GetRouteDesVins_ReturnsAllRoutes()
        {
            // Arrange
            RouteDesVins r1 = new RouteDesVins
            {
                IdRoute = 1,
                LibRoute = "ROUTE DES VINS D'ALSACE",
                DescriptionRoute = "Sans doute la plus connue des routes des vins en France, et assurément la plus ancienne ! Que cela soit à vélo ou en voiture, la routes des vins d'Alsace est parcourue par des millions de touristes chaque année, en quête de ses grands crus, ses fabuleux cépages, ses spécificités viticoles (citons les vendanges tardives), ses paysages vallonnés et villages pittoresques comme Colmar ou Riquewihr. Les vins d'Alsace, principalement blancs, sont réputés pour leur élégance, fraicheur et finesse. ",
                PhotoRoute = "ALSACE.png"
            };

            RouteDesVins r2 = new RouteDesVins
            {
                IdRoute = 2,
                LibRoute = "ROUTE DES VINS DU BEAUJOLAIS",
                DescriptionRoute = "Le Beaujolais Nouveau, bien sûr, mais pas que ! Vignoble souvent associé à sa production la plus médiatisée, le Beaujolais offre une incroyable diversité aromatique. Sans oublier de mentionner les paysages viticoles parmi les plus beaux de France en plein coeur du Vaux-en-Beaujolais, ...",
                PhotoRoute = "BEAUJOLAIS.png"
            };

            List<RouteDesVins> listeEsperee = new List<RouteDesVins>();
            listeEsperee.Add(r1);
            listeEsperee.Add(r2);

            // Act
            var result = await _controller.GetRouteDesVins();

            // Assert
            var actionResult = result as ActionResult<IEnumerable<RouteDesVins>>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<RouteDesVins>>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            CollectionAssert.AreEqual(listeEsperee, actionResult.Value.Where(r => r.IdRoute <= 2).ToList(), "Collections différentes");
        }

        [TestMethod()]
        public async Task GetRouteDesVinsById_ExistingId_ReturnsRoute()
        {
            // Arrange
            RouteDesVins r1 = new RouteDesVins
            {
                IdRoute = 1,
                LibRoute = "ROUTE DES VINS D'ALSACE",
                DescriptionRoute = "Sans doute la plus connue des routes des vins en France, et assurément la plus ancienne ! Que cela soit à vélo ou en voiture, la routes des vins d'Alsace est parcourue par des millions de touristes chaque année, en quête de ses grands crus, ses fabuleux cépages, ses spécificités viticoles (citons les vendanges tardives), ses paysages vallonnés et villages pittoresques comme Colmar ou Riquewihr. Les vins d'Alsace, principalement blancs, sont réputés pour leur élégance, fraicheur et finesse. ",
                PhotoRoute = "ALSACE.png"
            };

            // Act
            var result = await _controller.GetRouteDesVinsById(1);

            // Assert
            var actionResult = result as ActionResult<RouteDesVins>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<RouteDesVins>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(r1, actionResult.Value, "Routes différentes");
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetRouteDesVinsById_UnknownId_ReturnsNotFound()
        {
            // Act
            var result = await _controller.GetRouteDesVinsById(1000);

            // Assert
            var actionResult = result as ActionResult<RouteDesVins>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<RouteDesVins>), "Pas ActionResult");
            
            Assert.AreEqual(((NotFoundResult)actionResult.Result).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod()]
        public async Task GetRouteDesVinsByTitle_ExistingTitle_ReturnsRoute()
        {
            // Arrange
            RouteDesVins r1 = new RouteDesVins
            {
                IdRoute = 1,
                LibRoute = "ROUTE DES VINS D'ALSACE",
                DescriptionRoute = "Sans doute la plus connue des routes des vins en France, et assurément la plus ancienne ! Que cela soit à vélo ou en voiture, la routes des vins d'Alsace est parcourue par des millions de touristes chaque année, en quête de ses grands crus, ses fabuleux cépages, ses spécificités viticoles (citons les vendanges tardives), ses paysages vallonnés et villages pittoresques comme Colmar ou Riquewihr. Les vins d'Alsace, principalement blancs, sont réputés pour leur élégance, fraicheur et finesse. ",
                PhotoRoute = "ALSACE.png"
            };

            // Act
            var result = await _controller.GetRouteDesVinsByTitle("ROUTE DES VINS D'ALSACE");

            // Assert
            var actionResult = result as ActionResult<RouteDesVins>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<RouteDesVins>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(r1, actionResult.Value, "Routes différentes");
        }

       

        [TestMethod()]
        public async Task DeleteRouteDesVins_ExistingId_ReturnsNoContent()
        {
            // Arrange
            // Créer une nouvelle route temporaire pour le test de suppression
            RouteDesVins tempRoute = new RouteDesVins
            {
                IdRoute = 9999, // ID temporaire
                LibRoute = "Route Temporaire",
                DescriptionRoute = "Route créée pour le test de suppression",
                PhotoRoute = "temp_photo.jpg"
            };

            await _context.RouteDesVins.AddAsync(tempRoute);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteRouteDesVins(9999);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 204");

            // Vérifier que la route a bien été supprimée
            var deletedRoute = await _context.RouteDesVins.FindAsync(9999);
            Assert.IsNull(deletedRoute, "La route n'a pas été supprimée");
        }

        

        [TestMethod()]
        public async Task PutRouteDesVins_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            // Créer une nouvelle route temporaire pour le test de mise à jour
            RouteDesVins tempRoute = new RouteDesVins
            {
                IdRoute = 8888, // ID temporaire
                LibRoute = "Route Originale",
                DescriptionRoute = "Description originale",
                PhotoRoute = "original_photo.jpg"
            };

            await _context.RouteDesVins.AddAsync(tempRoute);
            await _context.SaveChangesAsync();
            _routesToCleanup.Add(8888); // Ajouter à la liste de nettoyage

            RouteDesVins updatedRoute = new RouteDesVins
            {
                IdRoute = 8888,
                LibRoute = "Route Mise à Jour",
                DescriptionRoute = "Description mise à jour",
                PhotoRoute = "updated_photo.jpg"
            };

            // Act
            var result = await _controller.PutRouteDesVins(8888, updatedRoute);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 204");

            // Vérifier que la route a bien été mise à jour
            var routeFromDb = await _context.RouteDesVins.FindAsync(8888);
            Assert.AreEqual("Route Mise à Jour", routeFromDb.LibRoute, "Le titre n'a pas été mis à jour");
        }

        [TestMethod()]
        public async Task PutRouteDesVins_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            RouteDesVins updatedRoute = new RouteDesVins
            {
                IdRoute = 7777,
                LibRoute = "Route des Vins d'Alsace Mise à Jour",
                DescriptionRoute = "Description mise à jour de la route à travers les vignobles alsaciens...",
                PhotoRoute = "photo2_updated.jpg"
            };

            // Act
            var result = await _controller.PutRouteDesVins(6666, updatedRoute);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((BadRequestResult)actionResult).StatusCode, StatusCodes.Status400BadRequest, "Pas 400");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task PutRouteDesVins_UnknownId_ThrowsException()
        {
            // Arrange
            RouteDesVins updatedRoute = new RouteDesVins
            {
                IdRoute = 1000,
                LibRoute = "Route Inconnue",
                DescriptionRoute = "Description d'une route inconnue...",
                PhotoRoute = "photo_unknown.jpg"
            };

            // Act
            await _controller.PutRouteDesVins(1000, updatedRoute);
        }

        [TestMethod()]
        public async Task PostRouteDesVins_ValidRoute_ReturnsCreatedAtAction()
        {
            // Arrange
            // Utiliser un ID qui ne risque pas de conflit avec les routes existantes
            RouteDesVins newRoute = new RouteDesVins
            {
                IdRoute = 7777, // ID temporaire élevé pour éviter les conflits
                LibRoute = "Nouvelle Route des Vins",
                DescriptionRoute = "Description d'une nouvelle route des vins pour test...",
                PhotoRoute = "test_photo.jpg"
            };

            // Act
            var result = await _controller.PostRouteDesVins(newRoute);

            // Assert
            var actionResult = result as ActionResult<RouteDesVins>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<RouteDesVins>), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas CreatedAtActionResult");

            var createdAtActionResult = (CreatedAtActionResult)actionResult.Result;
            Assert.AreEqual("GetById", createdAtActionResult.ActionName, "Mauvais nom d'action");

            // Ajouter la route à la liste de nettoyage
            _routesToCleanup.Add(7777);
        }

    }
}