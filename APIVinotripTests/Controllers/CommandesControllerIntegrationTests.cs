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
    public class CommandesControllerIntegrationTests
    {
        private CommandesController _controller;
        private DBVinotripContext _context;
        private ICommandeRepository<Commande> _repository;
        private List<int> _commandesToCleanup; // Liste pour suivre les commandes à nettoyer

        [TestInitialize]
        public void Initialize()
        {
            // Configuration de la connexion à la base de données
            var builder = new DbContextOptionsBuilder<DBVinotripContext>()
                .UseNpgsql("Server=localhost;port=5432;Database=DBVinotrip;uid=postgres;password=postgres");
            _context = new DBVinotripContext(builder.Options);

            // Créer un repository pour les commandes
            _repository = new CommandeManager(_context);

            // Créer le contrôleur avec les dépendances
            _controller = new CommandesController(_repository);

            // Initialiser la liste des commandes à nettoyer
            _commandesToCleanup = new List<int>();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            // Nettoyer toutes les commandes créées pendant les tests
            foreach (var commandeId in _commandesToCleanup)
            {
                try
                {
                    var commande = await _context.Commandes.FindAsync(commandeId);
                    if (commande != null)
                    {
                        _context.Commandes.Remove(commande);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors du nettoyage de la commande {commandeId}: {ex.Message}");
                }
            }

            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
        }

        [TestMethod()]
        public async Task GetCommandes_ReturnsAllCommandes()
        {
            // Arrange
            Commande c1 = new Commande
            {
                IdCommande = 1,
                IdCodePromo = null,
                IdCB = 1,
                IdAdresseFacturation = 30,
                IdClientAcheteur = 31,
                IdClientBeneficiaire = 27,
                IdAdresseLivraison = 11,
                IdPanier = 110,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "Paiement validé",
                TypePayementCommande = "cb",
                DateCommande = new DateTime(2024, 06, 05)
            };

            Commande c2 = new Commande
            {
                IdCommande = 2,
                IdCodePromo = null,
                IdCB = null,
                IdAdresseFacturation = 1,
                IdClientAcheteur = 11,
                IdClientBeneficiaire = 31,
                IdAdresseLivraison = 31,
                IdPanier = 112,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "En attente de validation",
                TypePayementCommande = "stripe",
                DateCommande = new DateTime(2024, 07, 21)
            };

            List<Commande> listeEsperee = new List<Commande>();
            listeEsperee.Add(c1);
            listeEsperee.Add(c2);

            // Act
            var result = await _controller.GetCommandes();

            // Assert
            var actionResult = result as ActionResult<IEnumerable<Commande>>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<Commande>>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            CollectionAssert.AreEqual(listeEsperee, actionResult.Value.Where(c => c.IdCommande <= 2).ToList(), "Collections différentes");
        }

        [TestMethod()]
        public async Task GetCommandeById_ExistingId_ReturnsCommande()
        {
            // Arrange
            Commande c1 = new Commande
            {
                IdCommande = 1,
                IdCodePromo = null,
                IdCB = 1,
                IdAdresseFacturation = 30,
                IdClientAcheteur = 31,
                IdClientBeneficiaire = 27,
                IdAdresseLivraison = 11,
                IdPanier = 110,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "Paiement validé",
                TypePayementCommande = "cb",
                DateCommande = new DateTime(2024, 06, 05)
            };

            // Act
            var result = await _controller.GetCommandeById(1);

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(c1, actionResult.Value, "Commandes différentes");
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetCommandeById_UnknownId_ReturnsNull()
        {
            // Act
            var result = await _controller.GetCommandeById(9999);

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            
            Assert.AreEqual(((NotFoundResult)actionResult.Result).StatusCode, StatusCodes.Status204NoContent, "Pas 404");
        }

        [TestMethod()]
        public async Task GetCommandeByState_ExistingState_ReturnsCommande()
        {
            // Arrange
            Commande c1 = new Commande
            {
                IdCommande = 1,
                IdCodePromo = null,
                IdCB = 1,
                IdAdresseFacturation = 30,
                IdClientAcheteur = 31,
                IdClientBeneficiaire = 27,
                IdAdresseLivraison = 11,
                IdPanier = 110,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "Paiement validé",
                TypePayementCommande = "cb",
                DateCommande = new DateTime(2024, 06, 05)
            };

            // Act
            var result = await _controller.GetCommandeByState("Paiement validé");

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(c1, actionResult.Value, "Commandes différentes");
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task GetCommandeByState_UnknownState_ReturnsNoContent()
        {
            // Act
            var result = await _controller.GetCommandeByState("État Inexistant");

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            
            Assert.AreEqual(((NoContentResult)actionResult.Result).StatusCode, StatusCodes.Status204NoContent, "Pas 404");
        }

        [TestMethod()]
        public async Task GetCommandesByIdClient_ExistingId_ReturnsCommandes()
        {
            // Arrange - on utilise un ID client qui existe dans la base
            int clientId = 31; // Cet ID apparaît dans les deux premières commandes de l'exemple

            // Act
            var result = await _controller.GetCommandesByIdClient(clientId);

            // Assert
            var actionResult = result as ActionResult<IEnumerable<Commande>>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<Commande>>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.IsTrue(actionResult.Value.Count() > 0, "Aucune commande trouvée");
            Assert.IsTrue(actionResult.Value.All(c => c.IdClientAcheteur == clientId || c.IdClientBeneficiaire == clientId),
                "Certaines commandes ne correspondent pas au client");
        }

        [TestMethod()]
        public async Task GetCommandeByIdPanier_ExistingId_ReturnsCommande()
        {
            // Arrange
            int panierId = 110; // Cet ID apparaît dans la première commande de l'exemple

            // Act
            var result = await _controller.GetCommandeByIdPanier(panierId);

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            Assert.IsNotNull(actionResult, "ActionResult null");
            Assert.IsNotNull(actionResult.Value, "Valeur nulle");
            Assert.AreEqual(panierId, actionResult.Value.IdPanier, "Le panier ID ne correspond pas");
        }

        [TestMethod()]
        public async Task DeleteCommande_ExistingId_ReturnsNoContent()
        {
            // Arrange
            // Trouver un panier existant dans la base de données
            var existingPanier = await _context.Paniers.FirstOrDefaultAsync();
            Assert.IsNotNull(existingPanier, "Aucun panier trouvé dans la base de données pour le test");
            int panierId = existingPanier.IdPanier;

            // Trouver des IDs d'entités valides pour la commande
            var existingClient = await _context.Clients.FirstOrDefaultAsync();
            Assert.IsNotNull(existingClient, "Aucun client trouvé dans la base de données pour le test");
            int clientId = existingClient.IdClient;

            var existingAdresse = await _context.Adresses.FirstOrDefaultAsync();
            Assert.IsNotNull(existingAdresse, "Aucune adresse trouvée dans la base de données pour le test");
            int adresseId = existingAdresse.IdAdresse;

            // Créer une nouvelle commande temporaire pour le test de suppression
            Commande tempCommande = new Commande
            {
                IdCommande = 9999, // ID temporaire
                IdCodePromo = null,
                IdCB = null,
                IdAdresseFacturation = adresseId,
                IdClientAcheteur = clientId,
                IdClientBeneficiaire = clientId,
                IdAdresseLivraison = adresseId,
                IdPanier = panierId,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "Test de suppression",
                TypePayementCommande = "test",
                DateCommande = DateTime.Now
            };

            await _context.Commandes.AddAsync(tempCommande);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteCommande(9999);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 204");

            // Vérifier que la commande a bien été supprimée
            var deletedCommande = await _context.Commandes.FindAsync(9999);
            Assert.IsNull(deletedCommande, "La commande n'a pas été supprimée");
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DeleteCommande_UnknownId_ReturnsNoContent()
        {
            // Act
            var result = await _controller.DeleteCommande(1999);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas NoContentResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 404");
        }

        [TestMethod()]
        public async Task PutCommande_ValidUpdate_ReturnsNoContent()
        {
            // Arrange
            // Trouver un panier existant dans la base de données
            var existingPanier = await _context.Paniers.FirstOrDefaultAsync();
            Assert.IsNotNull(existingPanier, "Aucun panier trouvé dans la base de données pour le test");
            int panierId = existingPanier.IdPanier;

            // Trouver des IDs d'entités valides pour la commande
            var existingClient = await _context.Clients.FirstOrDefaultAsync();
            Assert.IsNotNull(existingClient, "Aucun client trouvé dans la base de données pour le test");
            int clientId = existingClient.IdClient;

            var existingAdresse = await _context.Adresses.FirstOrDefaultAsync();
            Assert.IsNotNull(existingAdresse, "Aucune adresse trouvée dans la base de données pour le test");
            int adresseId = existingAdresse.IdAdresse;

            // Créer une nouvelle commande temporaire pour le test de mise à jour
            Commande tempCommande = new Commande
            {
                IdCommande = 8888, // ID temporaire
                IdCodePromo = null,
                IdCB = null,
                IdAdresseFacturation = adresseId,
                IdClientAcheteur = clientId,
                IdClientBeneficiaire = clientId,
                IdAdresseLivraison = adresseId,
                IdPanier = panierId,
                ValidationClient = false,
                codereduction = null,
                EtatCommande = "État original",
                TypePayementCommande = "original",
                DateCommande = DateTime.Now.AddDays(-1)
            };

            await _context.Commandes.AddAsync(tempCommande);
            await _context.SaveChangesAsync();
            _commandesToCleanup.Add(8888); // Ajouter à la liste de nettoyage

            Commande updatedCommande = new Commande
            {
                IdCommande = 8888,
                IdCodePromo = null,
                IdCB = null,
                IdAdresseFacturation = adresseId,
                IdClientAcheteur = clientId,
                IdClientBeneficiaire = clientId,
                IdAdresseLivraison = adresseId,
                IdPanier = panierId, // Utiliser le même panier
                ValidationClient = true, // Modifié
                codereduction = "TEST10", // Ajouté
                EtatCommande = "État mis à jour", // Modifié
                TypePayementCommande = "mis à jour", // Modifié
                DateCommande = DateTime.Now // Modifié
            };

            // Act
            var result = await _controller.PutCommande(8888, updatedCommande);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 204");

            // Vérifier que la commande a bien été mise à jour
            var commandeFromDb = await _context.Commandes.FindAsync(8888);
            Assert.AreEqual("État mis à jour", commandeFromDb.EtatCommande, "L'état n'a pas été mis à jour");
            Assert.AreEqual("TEST10", commandeFromDb.codereduction, "Le code de réduction n'a pas été mis à jour");
            Assert.IsTrue(commandeFromDb.ValidationClient, "ValidationClient n'a pas été mis à jour");
        }


        [TestMethod()]
        public async Task PutCommande_IdMismatch_ReturnsBadRequest()
        {
            // Arrange
            Commande updatedCommande = new Commande
            {
                IdCommande = 7777,
                EtatCommande = "État mis à jour"
            };

            // Act
            var result = await _controller.PutCommande(6666, updatedCommande);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.AreEqual(((BadRequestResult)actionResult).StatusCode, StatusCodes.Status400BadRequest, "Pas 400");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task PutCommande_UnknownId_ReturnsNoContent()
        {
            // Arrange
            Commande updatedCommande = new Commande
            {
                IdCommande = 99999,
                IdCodePromo = null,
                IdCB = 1,
                IdAdresseFacturation = 1,
                IdClientAcheteur = 1,
                IdClientBeneficiaire = 1,
                IdAdresseLivraison = 1,
                IdPanier = 999,
                ValidationClient = true,
                codereduction = "TEST10",
                EtatCommande = "État inexistant",
                TypePayementCommande = "test",
                DateCommande = DateTime.Now
            };

            // Act
            var result = await _controller.PutCommande(99999, updatedCommande);

            // Assert
            var actionResult = result as ActionResult;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas NoContentResult");
            Assert.AreEqual(((NoContentResult)actionResult).StatusCode, StatusCodes.Status204NoContent, "Pas 404");
        }

        [TestMethod()]
        public async Task PostCommande_ValidCommande_ReturnsCreatedAtAction()
        {
            // Arrange
            // Trouver un panier existant dans la base de données
            var existingPanier = await _context.Paniers.FirstOrDefaultAsync();
            Assert.IsNotNull(existingPanier, "Aucun panier trouvé dans la base de données pour le test");
            int panierId = existingPanier.IdPanier;

            // Trouver des IDs d'entités valides pour la commande
            var existingClient = await _context.Clients.FirstOrDefaultAsync();
            Assert.IsNotNull(existingClient, "Aucun client trouvé dans la base de données pour le test");
            int clientId = existingClient.IdClient;

            var existingAdresse = await _context.Adresses.FirstOrDefaultAsync();
            Assert.IsNotNull(existingAdresse, "Aucune adresse trouvée dans la base de données pour le test");
            int adresseId = existingAdresse.IdAdresse;

            // Utiliser un ID qui ne risque pas de conflit avec les commandes existantes
            Commande newCommande = new Commande
            {
                IdCommande = 7777, // ID temporaire élevé pour éviter les conflits
                IdCodePromo = null,
                IdCB = null,
                IdAdresseFacturation = adresseId,
                IdClientAcheteur = clientId,
                IdClientBeneficiaire = clientId,
                IdAdresseLivraison = adresseId,
                IdPanier = panierId,
                ValidationClient = false,
                codereduction = "NOUVEAU10",
                EtatCommande = "Nouvelle commande",
                TypePayementCommande = "test",
                DateCommande = DateTime.Now
            };

            // Act
            var result = await _controller.PostCommande(newCommande);

            // Assert
            var actionResult = result as ActionResult<Commande>;
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Commande>), "Pas ActionResult");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas CreatedAtActionResult");

            var createdAtActionResult = (CreatedAtActionResult)actionResult.Result;
            Assert.AreEqual("GetById", createdAtActionResult.ActionName, "Mauvais nom d'action");
            Assert.AreEqual(newCommande, createdAtActionResult.Value, "Commandes différentes");

            // Ajouter la commande à la liste de nettoyage
            _commandesToCleanup.Add(7777);
        }


       
    }
}