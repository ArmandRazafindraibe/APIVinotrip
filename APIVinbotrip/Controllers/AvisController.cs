using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les avis des utilisateurs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AvisController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des avis
        /// </summary>
        private readonly IDataRepository<Avis> dataRepository;

        /// <summary>
        /// Constructeur du contrôleur AvisController
        /// </summary>
        /// <param name="dataRepos">Repository d'accès aux données</param>
        public AvisController(IDataRepository<Avis> dataRepos)
        {
            dataRepository = dataRepos;
        }

        /// <summary>
        /// Récupère la liste de tous les avis
        /// </summary>
        /// <returns>Collection d'objets Avis</returns>
        // GET: api/Avis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avis>>> GetAvis()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère un avis spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'avis à récupérer</param>
        /// <returns>L'objet Avis correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Avis/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avis>> GetAvisById(int id)
        {
            var avis = await dataRepository.GetById(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Récupère un avis spécifique par son titre
        /// </summary>
        /// <param name="title">Titre de l'avis à récupérer</param>
        /// <returns>L'objet Avis correspondant au titre ou NotFound si non trouvé</returns>
        // GET: api/Avis/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAvisByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avis>> GetAvisByTitle(string title)
        {
            var avis = await dataRepository.GetByString(title);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        /// <summary>
        /// Met à jour un avis existant
        /// </summary>
        /// <param name="id">Identifiant de l'avis à mettre à jour</param>
        /// <param name="avis">Objet Avis contenant les nouvelles données</param>
        /// <returns>NoContent si la mise à jour est réussie, BadRequest si l'identifiant ne correspond pas, NotFound si l'avis n'existe pas</returns>
        // PUT: api/Avis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAvis(int id, Avis avis)
        {
            if (id != avis.IdAvis)
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
                await dataRepository.Update(userToUpdate.Value, avis);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée un nouvel avis
        /// </summary>
        /// <param name="avis">Objet Avis à créer</param>
        /// <returns>L'avis créé avec son URI d'accès, ou BadRequest si le modèle est invalide</returns>
        // POST: api/Avis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Avis>> PostAvis(Avis avis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(avis);

            return CreatedAtAction("GetById", new { id = avis.IdAvis }, avis); // GetById : nom de l'action
        }

        /// <summary>
        /// Supprime un avis spécifique
        /// </summary>
        /// <param name="id">Identifiant de l'avis à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si l'avis n'existe pas</returns>
        // DELETE: api/Avis/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAvis(int id)
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