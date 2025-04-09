using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapesController : ControllerBase
    {
        private readonly IEtapeRepository<Etape> dataRepository;
         

        public EtapesController(IEtapeRepository<Etape> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Etapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etape>>> GetEtapes()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Etapes/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Etape>> GetEtapeById(int id)
        {
            var etape = await dataRepository.GetById(id);

            if (etape == null)
            {
                return NotFound();
            }

            return  etape;
        }

        // GET: api/Etapes/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetEtapeByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Etape>> GetEtapeByState(string etat)
        {
            var etape = await dataRepository.GetByString(etat);

            if (etape == null)
            {
                return NotFound();
            }

            return  etape;
        }


        [HttpGet]
        [Route("[action]")]
        [ActionName("GetAllEtapeWithActivite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Etape>>> GetAllEtapeWithActivite()
        {
            return await dataRepository.GetAllEtapeWithActivite();
        }

        // PUT: api/Etapes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutEtape(int id, Etape etape)
        {
            if (id != etape.IdEtape)
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
                await dataRepository.Update(userToUpdate.Value, etape);
                return NoContent();
            }
        }

        // POST: api/Etapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Etape>> PostEtape(Etape etape)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(etape);

            return CreatedAtAction("GetById", new { id = etape.IdEtape }, etape); // GetById : nom de l’action
        }

        // DELETE: api/Etapes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEtape(int id)
        {
            var etape = await dataRepository.GetById(id);
            if (etape == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(etape.Value);
            return NoContent();
        }

        //private bool EtapeExists(int id)
        //{
        //    return _context.Etapes.Any(e => e.Idetape == id);
        //}
    }
}
