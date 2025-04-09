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
        private readonly ICommandeRepository<Commande> dataRepository;
         

        public CommandesController(ICommandeRepository<Commande> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await dataRepository.GetAll();
        }

        [HttpGet]
        [Route("[action]")]
        [ActionName("GetCommandesByIdClient")]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandesByIdClient(int id)
        {
            return await dataRepository.GetAllCommandesByIdClient(id);
        }

        [HttpGet]
        [Route("[action]")]
        [ActionName("GetCommandesByIdPanier")]
        public async Task<ActionResult<Commande>> GetCommandeByIdPanier(int id)
        {
            return await dataRepository.GetCommandeByIdPanier(id);
        }
        // GET: api/Commandes/GetById/5
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

            var entityToUpdate = await dataRepository.GetById(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.Update(entityToUpdate.Value, commande);
                return NoContent();
            }
        }

        [HttpPut()]
        [Route("[action]/{id}")]
        [ActionName("UpdateDescriptionCommande")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDetailCommande(int id, DescriptionCommande desccommande)
        {
            if (id != desccommande.IdCommande)
            {
                return BadRequest();
            }

            var entityToUpdate = await dataRepository.GetDescriptionCommandeByIdDescription(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateDescriptionCommande(entityToUpdate.Value, desccommande);
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


        [HttpPost]
        [Route("[action]")]
        [ActionName("PostDescriptionCommande")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DescriptionCommande>> PostDescriptionCommande(DescriptionCommande desccommande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddDescriptionCommande(desccommande);

            return CreatedAtAction("GetById", new { id = desccommande.IdCommande }, desccommande); // GetById : nom de l’action
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
