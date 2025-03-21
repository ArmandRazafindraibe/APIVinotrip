using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorisController : ControllerBase
    {
        private readonly IDataRepository<Favoris> dataRepository;
        //private readonly FilmRatingsDBContext _context; 

        public FavorisController(IDataRepository<Favoris> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Favoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favoris>>> GetFavoris()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Favoris/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Favoris>> GetFavorisById(int id)
        {
            var favoris =  await dataRepository.GetById(id);

            if (favoris == null)
            {
                return NotFound();
            }

            return   favoris;
        }

        // GET: api/Favoris/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetFavorisByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Favoris>> GetFavorisByTitle(string title)
        {
            var favoris = await dataRepository.GetByString(title);

            if (favoris == null)
            {
                return NotFound();
            }

            return  favoris;
        }

        // PUT: api/Favoris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFavoris(int id, Favoris favoris)
        {
            if (id != favoris.IdSejour)
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
               await  dataRepository.Update(userToUpdate.Value, favoris);
                return NoContent();
            }
        }

        // POST: api/Favoris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Favoris>> PostFavoris(Favoris favoris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(favoris);

            return CreatedAtAction("GetById", new { id = favoris.IdSejour }, favoris); // GetById : nom de l’action
        }

        // DELETE: api/Favoris/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFavoris(int id)
        {
            var favoris = await dataRepository.GetById(id);
            if (favoris == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(favoris.Value);
            return NoContent();
        }

        //private bool FavorisExists(int id)
        //{
        //    return _context.Favoris.Any(e => e.Idfavoris == id);
        //}
    }
}
