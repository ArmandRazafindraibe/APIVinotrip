using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    /// <summary>
    /// Contrôleur permettant de gérer les adresses
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        /// <summary>
        /// Interface du repository pour accéder aux données des adresses
        /// </summary>
        private readonly IDataRepository<Adresse> dataRepository;
        //private readonly FilmRatingsDBContext _context; 

        /// <summary>
        /// Constructeur du contrôleur AdressesController
        /// </summary>
        /// <param name="dataRepos">Repository d'accès aux données</param>
        public AdressesController(IDataRepository<Adresse> dataRepos)
        {
            dataRepository = dataRepos;
        }

        /// <summary>
        /// Récupère la liste de toutes les adresses
        /// </summary>
        /// <returns>Collection d'objets Adresse</returns>
        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
            return await dataRepository.GetAll();
        }

        /// <summary>
        /// Récupère une adresse spécifique par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'adresse à récupérer</param>
        /// <returns>L'objet Adresse correspondant à l'identifiant ou NotFound si non trouvé</returns>
        // GET: api/Adresses/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseById(int id)
        {
            var adresse = await dataRepository.GetById(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        /// <summary>
        /// Récupère une adresse spécifique par son titre
        /// </summary>
        /// <param name="title">Titre de l'adresse à récupérer</param>
        /// <returns>L'objet Adresse correspondant au titre ou NotFound si non trouvé</returns>
        // GET: api/Adresses/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAdresseByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseByTitle(string title)
        {
            var adresse = await dataRepository.GetByString(title);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        /// <summary>
        /// Met à jour une adresse existante
        /// </summary>
        /// <param name="id">Identifiant de l'adresse à mettre à jour</param>
        /// <param name="adresse">Objet Adresse contenant les nouvelles données</param>
        /// <returns>NoContent si la mise à jour est réussie, BadRequest si l'identifiant ne correspond pas, NotFound si l'adresse n'existe pas</returns>
        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.IdAdresse)
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
                await dataRepository.Update(userToUpdate.Value, adresse);
                return NoContent();
            }
        }

        /// <summary>
        /// Crée une nouvelle adresse
        /// </summary>
        /// <param name="adresse">Objet Adresse à créer</param>
        /// <returns>L'adresse créée avec son URI d'accès, ou BadRequest si le modèle est invalide</returns>
        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(adresse);

            return CreatedAtAction("GetById", new { id = adresse.IdAdresse }, adresse); // GetById : nom de l'action
        }

        /// <summary>
        /// Supprime une adresse spécifique
        /// </summary>
        /// <param name="id">Identifiant de l'adresse à supprimer</param>
        /// <returns>NoContent si la suppression est réussie, NotFound si l'adresse n'existe pas</returns>
        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var adresse = await dataRepository.GetById(id);
            if (adresse == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(adresse.Value);
            return NoContent();
        }

    }
}