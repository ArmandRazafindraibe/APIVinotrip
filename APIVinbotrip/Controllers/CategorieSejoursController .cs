using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les catégories de séjour
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesSejourController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des catégories de séjour
        /// </summary>
        private readonly IDataRepository<CategorieSejour> dataRepository;

        /// <summary>
        /// Constructeur du contrôleur CategoriesSejourController
        /// </summary>
        /// <param name="dataRepos">Repository d'accès aux données</param>
        public CategoriesSejourController(IDataRepository<CategorieSejour> dataRepos)
        {
            dataRepository = dataRepos;
        }

        /// <summary>
        /// Récupère la liste de toutes les catégories de séjour
        /// </summary>
        /// <returns>Collection d'objets CategorieSejour</returns>
        // GET: api/Aviss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieSejour>>> GetCategorieSejours()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère une catégorie de séjour spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de séjour à récupérer</param>
        /// <returns>L'objet CategorieSejour correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategorieSejour>> GetCategorieSejourById(int id)
        {
            var avis = await dataRepository.GetById(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Récupère une catégorie de séjour spécifique par son titre
        /// </summary>
        /// <param name="title">Titre de la catégorie de séjour à récupérer</param>
        /// <returns>L'objet CategorieSejour correspondant au titre ou NotFound si non trouvé</returns>
        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAvisByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategorieSejour>> GetCategorieSejourByTitle(string title)
        {
            var avis = await dataRepository.GetByString(title);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Met à jour une catégorie de séjour existante
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de séjour à mettre à jour</param>
        /// <param name="categorieSejour">Objet CategorieSejour contenant les nouvelles données</param>
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
        public async Task<IActionResult> PutCategorieSejour(int id, CategorieSejour categorieSejour)
        {
            if (id != categorieSejour.IdCategorieSejour)
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
                await dataRepository.Update(userToUpdate.Value, categorieSejour);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée une nouvelle catégorie de séjour
        /// </summary>
        /// <param name="categorieSejour">Objet CategorieSejour à créer</param>
        /// <returns>La catégorie créée avec son URI d'accès, ou BadRequest si le modèle est invalide</returns>
        /// <remarks>Nécessite l'autorisation ServiceVente ou Dirigeant</remarks>
        // POST: api/Aviss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<ActionResult<Avis>> PostCategorieSejour(CategorieSejour categorieSejour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(categorieSejour);

            return CreatedAtAction("GetById", new { id = categorieSejour.IdCategorieSejour }, categorieSejour); // GetById : nom de l'action
        }

        /// <summary>
        /// Supprime une catégorie de séjour spécifique
        /// </summary>
        /// <param name="id">Identifiant de la catégorie de séjour à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si la catégorie n'existe pas</returns>
        /// <remarks>Nécessite l'autorisation ServiceVente ou Dirigeant</remarks>
        // DELETE: api/Aviss/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> DeleteCategorieSejour(int id)
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