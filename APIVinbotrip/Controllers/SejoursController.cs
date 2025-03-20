using Microsoft.AspNetCore.Mvc;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SejoursController : ControllerBase
    {
        private readonly IDataRepository<Sejour> dataRepository;
        //private readonly FilmRatingsDBContext _context; 

        public SejoursController(IDataRepository<Sejour> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Sejours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sejour>>> GetSejours()
        {
            return await   dataRepository.GetAll();
        }

        // GET: api/Sejours/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sejour>> GetSejourById(int id)
        {
            var sejour = dataRepository.GetById(id);

            if (sejour == null)
            {
                return NotFound();
            }

            return await sejour;
        }

        // GET: api/Sejours/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetSejourByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sejour>> GetSejourByTitle(string title)
        {
            var sejour = dataRepository.GetByString(title);

            if (sejour == null)
            {
                return  NotFound();
            }

            return await sejour;
        }

        // PUT: api/Sejours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutSejour(int id, Sejour sejour)
        {
            if (id != sejour.Idsejour)
            {
                return  BadRequest();
            }

            var userToUpdate = await dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return  NotFound();
            }
            else
            {
                await  dataRepository.Update(userToUpdate.Value, sejour);
                return  NoContent();
            }
        }

            // POST: api/Sejours
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Sejour>> PostSejour(Sejour sejour)
            {
            if (!ModelState.IsValid)
            {
                return  BadRequest(ModelState);
            }

            dataRepository.Add(sejour);

            return  CreatedAtAction("GetById", new { id = sejour.Idsejour }, sejour); // GetById : nom de l’action
        }

        // DELETE: api/Sejours/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSejour(int id)
        {
            var sejour = dataRepository.GetById(id);
            if (sejour == null)
            {
                return  NotFound();
            }
            dataRepository.Delete(sejour.Result.Value);
            return  NoContent();
        }

        //private bool SejourExists(int id)
        //{
        //    return await _context.Sejours.Any(e => e.Idsejour == id);
        //}
    }
}
