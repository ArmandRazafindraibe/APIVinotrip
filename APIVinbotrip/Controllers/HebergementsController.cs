using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HebergementsController : ControllerBase
    {
        private readonly IDataRepository<Hebergement> dataRepository;
         

        public HebergementsController(IDataRepository<Hebergement> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Hebergements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hebergement>>> GetHebergements()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Hebergements/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hebergement>> GetHebergementById(int id)
        {
            var hebergement = await dataRepository.GetById(id);

            if (hebergement == null)
            {
                return NotFound();
            }

            return  hebergement;
        }

        // GET: api/Hebergements/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetHebergementByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Hebergement>> GetHebergementByState(string etat)
        {
            var hebergement = await dataRepository.GetByString(etat);

            if (hebergement == null)
            {
                return NotFound();
            }

            return  hebergement;
        }

        // PUT: api/Hebergements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutHebergement(int id, Hebergement hebergement)
        {
            if (id != hebergement.IdHebergement)
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
                await dataRepository.Update(userToUpdate.Value, hebergement);
                return NoContent();
            }
        }

        // POST: api/Hebergements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hebergement>> PostHebergement(Hebergement hebergement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(hebergement);

            return CreatedAtAction("GetById", new { id = hebergement.IdHebergement }, hebergement); // GetById : nom de l’action
        }

        // DELETE: api/Hebergements/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHebergement(int id)
        {
            var hebergement = await dataRepository.GetById(id);
            if (hebergement == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(hebergement.Value);
            return NoContent();
        }

        //private bool HebergementExists(int id)
        //{
        //    return _context.Hebergements.Any(e => e.Idhebergement == id);
        //}
    }
}
