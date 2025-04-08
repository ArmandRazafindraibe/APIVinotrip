using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartenaireController : ControllerBase
    {
        private readonly IDataRepository<Partenaire> dataRepository;

        public PartenaireController(IDataRepository<Partenaire> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partenaire>>> GetPartenaires()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Partenaire>> GetPartenaireById(int id)
        {
            var partenaire = await dataRepository.GetById(id);

            if (partenaire == null)
            {
                return NotFound();
            }

            return partenaire;
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetPanierByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Partenaire>> GetPartenaireByTitle(string title)
        {
            var partenaire = await dataRepository.GetByString(title);

            if (partenaire == null)
            {
                return NotFound();
            }

            return partenaire;
        }

        // PUT: api/Paniers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPartenaire(int id, Partenaire partenaire)
        {
            if (id != partenaire.IdPartenaire)
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
                await dataRepository.Update(userToUpdate.Value, partenaire);
                return NoContent();
            }
        }

        // POST: api/Paniers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Partenaire>> PostPartenaire(Partenaire partenaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(partenaire);

            return CreatedAtAction("GetById", new { id = partenaire.IdPartenaire }, partenaire); // GetById : nom de l’action
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePartenaire(int id)
        {
            var partenaire = await dataRepository.GetById(id);
            if (partenaire == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(partenaire.Value);
            return NoContent();
        }

        //private bool PanierExists(int id)
        //{
        //    return _context.Paniers.Any(e => e.Idpanier == id);
        //}
    }
}
