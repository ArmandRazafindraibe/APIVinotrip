using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        private readonly IDataRepository<Panier> dataRepository;

        public PanierController(IDataRepository<Panier> dataRepos)
        {
             dataRepository = dataRepos;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPaniers()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetPanierById(int id)
        {
            var panier =  await dataRepository.GetById(id);

            if (panier == null)
            {
                return NotFound();
            }

            return  panier;
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetPanierByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetPanierByTitle(string title)
        {
            var panier = await dataRepository.GetByString(title);

            if (panier == null)
            {
                return NotFound();
            }

            return  panier;
        }

        // PUT: api/Paniers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPanier(int id, Panier panier)
        {
            if (id != panier.IdPanier)
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
               await  dataRepository.Update(userToUpdate.Value, panier);
                return NoContent();
            }
        }

            // POST: api/Paniers
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Panier>> PostPanier(Panier panier)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(panier);

            return CreatedAtAction("GetById", new { id = panier.IdPanier }, panier); // GetById : nom de l’action
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePanier(int id)
        {
            var panier = await dataRepository.GetById(id);
            if (panier == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(panier.Value);
            return NoContent();
        }

        //private bool PanierExists(int id)
        //{
        //    return _context.Paniers.Any(e => e.Idpanier == id);
        //}
    }
}
