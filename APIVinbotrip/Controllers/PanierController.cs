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
    public class PanierController : ControllerBase
    {
        private readonly IPanierRepository<Panier> dataRepository;

        public PanierController(IPanierRepository<Panier> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPaniers()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetByIdPanier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetPanierById(int id)
        {
            var panier = await dataRepository.GetById(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetAllDescriptionPanier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DescriptionPanier>>> GetDescriptionsPanierById(int id)
        {
            var panier = await dataRepository.GetDescriptionsPanierById(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetOneDescriptionPanier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DescriptionPanier>> GetDescriptionPanierById(int id)
        {
            var panier = await dataRepository.GetOneDescriptionPanierById(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }


        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetAllDescriptionPanierDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DescriptionPanier>>> GetAllDescriptionPanierDetail(int id)
        {
            var panier = await dataRepository.GetAllDescriptionPanierDetail(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        // GET: api/Paniers/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetPanierByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Panier>> GetPanierByTitle(string title)
        {
            var panier = await dataRepository.GetByString(title);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }


        // PUT: api/Paniers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPanier(int id, Panier panier)
        {
            if (id != panier.IdPanier)
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
                await dataRepository.Update(userToUpdate.Value, panier);
                return NoContent();
            }
        }

        [HttpPut]
        [Route("[action]/{id}")]
        [ActionName("PutPanierDetail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPanierDetail(int id, DescriptionPanier panier)
        {
            if (id != panier.IdPanier)
            {
                return BadRequest();
            }

            var useToUpdate = await dataRepository.GetOneDescriptionPanierById(id);
            if (useToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateDetailPanier(useToUpdate.Value, panier);
                return NoContent();
            }
        }

        // POST: api/Paniers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostPanier")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Panier>> PostPanier(Panier panier)
        {
            Panier newpanier = new Panier();
            newpanier.DateAjoutPanier = panier.DateAjoutPanier;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(newpanier);

            // Correction ici - utiliser le nom d'action spécifié dans l'attribut ActionName
            return CreatedAtAction("GetByIdPanier", new { id = newpanier.IdPanier }, newpanier);
        }

        // POST: api/Paniers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostPanierDetail")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Panier>> PostPanierDetail(DescriptionPanier panier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddPanierDetail(panier);

            // Correction ici - utiliser le nom d'action spécifié dans l'attribut ActionName
            // Utiliser IdDescriptionPanier au lieu de IdPanier
            return CreatedAtAction("GetOneDescriptionPanier", new { id = panier.IdDescriptionPanier }, panier);
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePanier(int id)
        {
            var panier = await dataRepository.GetById(id);
            if (panier == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(panier.Value);
            return NoContent();
        }

        //private bool PanierExists(int id)
        //{
        //    return _context.Paniers.Any(e => e.Idpanier == id);
        //}
    }
}