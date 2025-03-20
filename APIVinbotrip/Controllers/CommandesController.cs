using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly IDataRepository<Commande> dataRepository;
         

        public CommandesController(IDataRepository<Commande> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Commandes/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commande>> GetCommandeById(int id)
        {
            var commande = await dataRepository.GetById(id);

            if (commande == null)
            {
                return NotFound();
            }

            return  commande;
        }

        // GET: api/Commandes/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetCommandeByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Commande>> GetCommandeByState(string etat)
        {
            var commande = await dataRepository.GetByString(etat);

            if (commande == null)
            {
                return NotFound();
            }

            return  commande;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.IdCommande)
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
                await dataRepository.Update(userToUpdate.Value, commande);
                return NoContent();
            }
        }

        // POST: api/Commandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(commande);

            return CreatedAtAction("GetById", new { id = commande.IdCommande }, commande); // GetById : nom de l’action
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await dataRepository.GetById(id);
            if (commande == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(commande.Value);
            return NoContent();
        }

        //private bool CommandeExists(int id)
        //{
        //    return _context.Commandes.Any(e => e.Idcommande == id);
        //}
    }
}
