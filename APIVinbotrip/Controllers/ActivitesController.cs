using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteController : ControllerBase
    {
        private readonly IDataRepository<Activite> dataRepository;

        public ActiviteController(IDataRepository<Activite> dataRepos)
        {
             dataRepository = dataRepos;
        }

        // GET: api/Activites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activite>>> GetActivites()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Activites/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Activite>> GetActiviteById(int id)
        {
            var activite =  await dataRepository.GetById(id);

            if (activite == null)
            {
                return NotFound();
            }

            return  activite;
        }

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

            return  activite;
        }

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
               await  dataRepository.Update(userToUpdate.Value, activite);
                return NoContent();
            }
        }

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

            return CreatedAtAction("GetById", new { id = activite.IdActivite }, activite); // GetById : nom de l’action
        }

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

        //private bool ActiviteExists(int id)
        //{
        //    return _context.Activites.Any(e => e.Idactivite == id);
        //}
    }
}
