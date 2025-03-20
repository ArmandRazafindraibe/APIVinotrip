using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IDataRepository<Adresse> dataRepository;
        //private readonly FilmRatingsDBContext _context; 

        public AdressesController(IDataRepository<Adresse> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Adresses/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseById(int id)
        {
            var adresse =  await dataRepository.GetById(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return   adresse;
        }

        // GET: api/Adresses/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetAdresseByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Adresse>> GetAdresseByTitle(string title)
        {
            var adresse = await dataRepository.GetByString(title);

            if (adresse == null)
            {
                return NotFound();
            }

            return  adresse;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.IdAdresse)
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
               await  dataRepository.Update(userToUpdate.Value, adresse);
                return NoContent();
            }
        }

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(adresse);

            return CreatedAtAction("GetById", new { id = adresse.IdAdresse }, adresse); // GetById : nom de l’action
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var adresse = await dataRepository.GetById(id);
            if (adresse == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(adresse.Value);
            return NoContent();
        }

        //private bool AdresseExists(int id)
        //{
        //    return _context.Adresses.Any(e => e.Idadresse == id);
        //}
    }
}
