using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les catégories de participant
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesParticipantController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des catégories de participant
        /// </summary>
        private readonly IDataRepository<CategorieParticipant> dataRepository;

        /// <summary>
        /// Constructeur du contrôleur CategoriesParticipantController
        /// </summary>
        /// <param name="dataRepos">Repository d'accès aux données</param>
        public CategoriesParticipantController(IDataRepository<CategorieParticipant> dataRepos)
        {
            dataRepository = dataRepos;
        }

        /// <summary>
        /// Récupère la liste de toutes les catégories de participant
        /// </summary>
        /// <returns>Collection d'objets CategorieParticipant</returns>
        // GET: api/Aviss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieParticipant>>> GetCategorieParticipants()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère une catégorie de participant spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de participant à récupérer</param>
        /// <returns>L'objet CategorieParticipant correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategorieParticipant>> GetCategorieParticipantById(int id)
        {
            var avis = await dataRepository.GetById(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Récupère une catégorie de participant spécifique par son titre
        /// </summary>
        /// <param name="title">Titre de la catégorie de participant à récupérer</param>
        /// <returns>L'objet CategorieParticipant correspondant au titre ou NotFound si non trouvé</returns>
        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAvisByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategorieParticipant>> GetCategorieParticipantByTitle(string title)
        {
            var avis = await dataRepository.GetByString(title);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Met à jour une catégorie de participant existante
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de participant à mettre à jour</param>
        /// <param name="categorieParticipant">Objet CategorieParticipant contenant les nouvelles données</param>
        /// <returns>NoContent si la mise à jour est réussie, BadRequest si l'identifiant ne correspond pas, NotFound si la catégorie n'existe pas</returns>
        /// <remarks>Nécessite l'autorisation ServiceVente ou Dirigeant</remarks>
        // PUT: api/Aviss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> PutCategorieParticipant(int id, CategorieParticipant categorieParticipant)
        {
            if (id != categorieParticipant.IdCategorieParticipant)
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
                await dataRepository.Update(userToUpdate.Value, categorieParticipant);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée une nouvelle catégorie de participant
        /// </summary>
        /// <param name="categorieParticipant">Objet CategorieParticipant à créer</param>
        /// <returns>La catégorie créée avec son URI d'accès, ou BadRequest si le modèle est invalide</returns>
        /// <remarks>Nécessite l'autorisation ServiceVente ou Dirigeant</remarks>
        // POST: api/Aviss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<ActionResult<Avis>> PostCategorieParticipant(CategorieParticipant categorieParticipant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(categorieParticipant);

            return CreatedAtAction("GetById", new { id = categorieParticipant.IdCategorieParticipant }, categorieParticipant); // GetById : nom de l'action
        }

        /// <summary>
        /// Supprime une catégorie de participant spécifique
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de participant à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si la catégorie n'existe pas</returns>
        /// <remarks>Nécessite l'autorisation ServiceVente ou Dirigeant</remarks>
        // DELETE: api/Aviss/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> DeleteCategorieParticipant(int id)
        {
            var avis = await dataRepository.GetById(id);
            if (avis == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(avis.Value);
            return NoContent();
        }
    }
}