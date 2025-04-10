using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les activités
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des activités
        /// </summary>
        private readonly IDataRepository<Activite> dataRepository;

        /// <summary>
        /// Constructeur du contrôleur ActivitesController
        /// </summary>
        /// <param name="dataRepos">Repository d'accès aux données</param>
        public ActivitesController(IDataRepository<Activite> dataRepos)
        {
            dataRepository = dataRepos;
        }

        /// <summary>
        /// Récupère la liste de toutes les activités
        /// </summary>
        /// <returns>Collection d'objets Activite</returns>
        // GET: api/Activites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère une activité spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'activité à récupérer</param>
        /// <returns>L'objet Activite correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Activites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            var activite = await dataRepository.GetById(id);

            if (activite == null)
            {
                return NotFound();
            }

            return activite;
        }

        /// <summary>
        /// Récupère une activité spécifique par son titre
        /// </summary>
        /// <param name="title">Titre de l'activité à récupérer</param>
        /// <returns>L'objet Activite correspondant au titre ou NotFound si non trouvé</returns>
        // GET: api/Activites/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetActiviteByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteByTitle(string title)
        {
            var activite = await dataRepository.GetByString(title);

            if (activite == null)
            {
                return NotFound();
            }

            return activite;
        }

        /// <summary>
        /// Met à jour une activité existante
        /// </summary>
        /// <param name="id">Identifiant de l'activité à mettre à jour</param>
        /// <param name="activite">Objet Activite contenant les nouvelles données</param>
        /// <returns>NoContent si la mise à jour est réussie, BadRequest si l'identifiant ne correspond pas, NotFound si l'activité n'existe pas</returns>
        // PUT: api/Activites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutActivite(int id, Activite activite)
        {
            if (id != activite.IdActivite)
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
                await dataRepository.Update(userToUpdate.Value, activite);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée une nouvelle activité
        /// </summary>
        /// <param name="activite">Objet Activite à créer</param>
        /// <returns>L'activité créée avec son URI d'accès, ou BadRequest si le modèle est invalide</returns>
        // POST: api/Activites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Activite>> PostActivite(Activite activite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(activite);

            return CreatedAtAction("GetById", new { id = activite.IdActivite }, activite); // GetById : nom de l'action
        }

        /// <summary>
        /// Supprime une activité spécifique
        /// </summary>
        /// <param name="id">Identifiant de l'activité à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si l'activité n'existe pas</returns>
        // DELETE: api/Activites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteActivite(int id)
        {
            var activite = await dataRepository.GetById(id);
            if (activite == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(activite.Value);
            return NoContent();
        }

      
    }
}