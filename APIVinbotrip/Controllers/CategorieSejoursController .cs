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
    public class CategorieSejourController : ControllerBase
    {
        private readonly IDataRepository<CategorieSejour> dataRepository;

        public CategorieSejourController(IDataRepository<CategorieSejour> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Aviss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieSejour>>> GetCategorieSejours()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategorieSejour>> GetCategorieSejourById(int id)
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
        public async Task<ActionResult<CategorieSejour>> GetCategorieSejourByTitle(string title)
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
        public async Task<IActionResult> PutCategorieSejour(int id, CategorieSejour categorieSejour)
        {
            if (id != categorieSejour.IdCategorieSejour)
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
                await dataRepository.Update(userToUpdate.Value, categorieSejour);
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
        public async Task<ActionResult<Avis>> PostCategorieSejour(CategorieSejour categorieSejour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(categorieSejour);

            return CreatedAtAction("GetById", new { id = categorieSejour.IdCategorieSejour }, categorieSejour); // GetById : nom de l’action
        }

        // DELETE: api/Aviss/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.ServiceVente)]
        [Authorize(Policy = Policies.Dirigeant)]
        public async Task<IActionResult> DeleteCategorieSejour(int id)
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
