using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using APIVinotrip.Helpers;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les clients
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des clients
        /// </summary>
        private readonly IDataRepository<Client> dataRepository;

        /// <summary>
        /// Constructeur du contrôleur ClientsController
        /// </summary>
        /// <param name="dataRepo">Repository d'accès aux données</param>
        public ClientsController(IDataRepository<Client> dataRepo)
        {
            dataRepository = dataRepo;
        }

        /// <summary>
        /// Récupère les données de l'utilisateur connecté
        /// </summary>
        /// <returns>Les données de l'utilisateur</returns>
        /// <remarks>Nécessite l'autorisation Client</remarks>
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = Policies.Client)]
        public IActionResult GetUserData()
        {
            return Ok("This is a response from user method");
        }

        /// <summary>
        /// Récupère les données administrateur
        /// </summary>
        /// <returns>Les données administrateur</returns>
        /// <remarks>Nécessite l'autorisation Dirigeant</remarks>
        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = Policies.Dirigeant)]
        public IActionResult GetAdminData()
        {
            return Ok("This is a response from Admin method");
        }

        /// <summary>
        /// Récupère la liste de tous les clients
        /// </summary>
        /// <returns>Collection d'objets Client</returns>
        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère un client spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du client à récupérer</param>
        /// <returns>L'objet Client correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Client/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var utilisateur = await dataRepository.GetById(id);
            //var utilisateur =  _context.Client.Find(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }

        /// <summary>
        /// Récupère un client spécifique par son adresse email
        /// </summary>
        /// <param name="email">Adresse email du client à récupérer</param>
        /// <returns>L'objet Client correspondant à l'email ou NotFound si non trouvé</returns>
        [HttpGet]
        [Route("[action]/{email}")]
        [ActionName("GetByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientByEmail(string email)
        {
            var utilisateur = await dataRepository.GetByString(email);
            //var utilisateur =  _context.Client.FirstOrDefault(e => e.Mail.ToUpper() == email.ToUpper());
            if (utilisateur == null)
            {
                return NotFound();
            }
            return utilisateur;
        }

        /// <summary>
        /// Met à jour un client existant
        /// </summary>
        /// <param name="id">Identifiant du client à mettre à jour</param>
        /// <param name="client">Objet Client contenant les nouvelles données</param>
        /// <returns>NoContent si la mise à jour est réussie, BadRequest si l'identifiant ne correspond pas, NotFound si le client n'existe pas</returns>
        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest();
            }
            var userToUpdate = await dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.Update(userToUpdate.Value, client);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée un nouveau client
        /// </summary>
        /// <param name="client">Objet Client à créer</param>
        /// <returns>Le client créé avec son URI d'accès, ou Conflict si l'email existe déjà</returns>
        /// <remarks>Cette méthode est accessible sans authentification et attribue automatiquement le rôle Client (IdRole = 1)</remarks>
        // POST: api/Clients
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            // Vérification si l'email existe déjà
            var existingClient = await dataRepository.GetAll();
            if (existingClient.Value.Any(c => c.EmailClient?.ToUpper() == client.EmailClient?.ToUpper()))
            {
                return Conflict(new { message = "Cet email est déjà utilisé." });
            }

            // Attribution du rôle Client par défaut
            client.IdRole = 1; // Rôle Client

            // Hacher le mot de passe avant de l'enregistrer
            string originalPassword = client.MdpClient;
            client.MdpClient = PasswordHasher.HashPassword(client.MdpClient);

            // Ne pas assigner le résultat à une variable
            await dataRepository.Add(client);


            return CreatedAtAction(nameof(GetClientById), new { id = client.IdClient }, client);
        }

        /// <summary>
        /// Supprime un client spécifique
        /// </summary>
        /// <param name="id">Identifiant du client à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si le client n'existe pas</returns>
        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var utilisateur = await dataRepository.GetById(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(utilisateur.Value);
            return NoContent();
        }
    }
}