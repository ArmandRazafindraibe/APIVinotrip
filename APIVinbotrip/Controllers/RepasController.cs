using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepasController : ControllerBase
    {
        private readonly IDataRepository<Repas> dataRepository;


        public RepasController(IDataRepository<Repas> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/RouteDesVins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repas>>> GetRepas()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/RouteDesVins/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Repas>> GetRepasById(int id)
        {
            var repas = await dataRepository.GetById(id);

            if (repas == null)
            {
                return NotFound();
            }

            return repas;
        }

        // GET: api/RouteDesVins/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetRouteDesVinsByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Repas>> GetRepasByTitle(string titre)
        {
            var repas = await dataRepository.GetByString(titre);

            if (repas == null)
            {
                return NotFound();
            }

            return repas;
        }

        // PUT: api/RouteDesVins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutRepas(int id, Repas repas)
        {
            if (id != repas.IdRepas)
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
                await dataRepository.Update(userToUpdate.Value, repas);
                return NoContent();
            }
        }

        // POST: api/RouteDesVins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Repas>> PostRepas(Repas repas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(repas);

            return CreatedAtAction("GetById", new { id = repas.IdRepas }, repas); // GetById : nom de l’action
        }

        // DELETE: api/RouteDesVins/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRepas(int id)
        {
            var repas = await dataRepository.GetById(id);
            if (repas == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(repas.Value);
            return NoContent();
        }

        //private bool RouteDesVinsExists(int id)
        //{
        //    return _context.RouteDesVins.Any(e => e.IdrouteDesVins == id);
        //}
    }
}
