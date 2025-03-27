using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Authorization;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DureeController : ControllerBase
    {
        private readonly IDataRepository<Duree> dataRepository;

        public DureeController(IDataRepository<Duree> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Aviss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Duree>>> GetDurees()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Duree>> GetDureeById(int id)
        {
            var avis = await dataRepository.GetById(id);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAvisByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Duree>> GetDureeByTitle(string title)
        {
            var avis = await dataRepository.GetByString(title);

            if (avis == null)
            {
                return NotFound();
            }

            return avis;
        }

        // PUT: api/Aviss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> PutDuree(int id, Duree Duree)
        {
            if (id != Duree.IdDuree)
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
                await dataRepository.Update(userToUpdate.Value, Duree);
                return NoContent();
            }
        }

        // POST: api/Aviss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<ActionResult<Avis>> PostDuree(Duree Duree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(Duree);

            return CreatedAtAction("GetById", new { id = Duree.IdDuree }, Duree); // GetById : nom de l’action
        }

        // DELETE: api/Aviss/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> DeleteDuree(int id)
        {
            var avis = await dataRepository.GetById(id);
            if (avis == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(avis.Value);
            return NoContent();
        }

        //private bool AvisExists(int id)
        //{
        //    return _context.Aviss.Any(e => e.Idavis == id);
        //}
    }
}
