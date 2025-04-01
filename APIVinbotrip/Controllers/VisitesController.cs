using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitesController : ControllerBase
    {
        private readonly IDataRepository<Visite> dataRepository;
         

        public VisitesController(IDataRepository<Visite> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Visites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visite>>> GetVisites()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Visites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Visite>> GetVisiteById(int id)
        {
            var visite = await dataRepository.GetById(id);

            if (visite == null)
            {
                return NotFound();
            }

            return  visite;
        }

        // GET: api/Visites/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetVisiteByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Visite>> GetVisiteByState(string etat)
        {
            var visite = await dataRepository.GetByString(etat);

            if (visite == null)
            {
                return NotFound();
            }

            return  visite;
        }

        // PUT: api/Visites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVisite(int id, Visite visite)
        {
            if (id != visite.IdVisite)
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
                await dataRepository.Update(userToUpdate.Value, visite);
                return NoContent();
            }
        }

        // POST: api/Visites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Visite>> PostVisite(Visite visite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(visite);

            return CreatedAtAction("GetById", new { id = visite.IdVisite }, visite); // GetById : nom de l’action
        }

        // DELETE: api/Visites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVisite(int id)
        {
            var visite = await dataRepository.GetById(id);
            if (visite == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(visite.Value);
            return NoContent();
        }

        //private bool VisiteExists(int id)
        //{
        //    return _context.Visites.Any(e => e.Idvisite == id);
        //}
    }
}
