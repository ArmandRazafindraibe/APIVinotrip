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
        [HttpPut]
        [Route("[action]")]
        [ActionName("UpdatePanierItemQuantity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePanierItemQuantity(int idDescriptionPanier, int quantite)
        {
            // Validation de base
            if (quantite < 1)
            {
                return BadRequest("La quantité doit être supérieure à 0");
            }
             // Récupérer la description du panier
                var descriptionPanier = await dataRepository.GetOneDescriptionPanierById(idDescriptionPanier);

                if (descriptionPanier == null)
                {
                    return NotFound();
                }

                var updatedDescriptionPanier = descriptionPanier.Value;
                updatedDescriptionPanier.Quantite = quantite;
                await dataRepository.UpdateDetailPanier(descriptionPanier.Value, updatedDescriptionPanier);
                return NoContent();
            }
        

        // POST: api/Paniers
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


            return CreatedAtAction("GetByIdPanier", new { id = newpanier.IdPanier }, newpanier);
        }

        // POST: api/Paniers Detail
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

            return CreatedAtAction("GetOneDescriptionPanier", new { id = panier.IdDescriptionPanier }, panier);
        }

        // DELETE: api/Panier/DeletePanier/{id}
        [HttpDelete]
        [Route("[action]/{id}")]
        [ActionName("DeletePanier")]
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

        // DELETE: api/Panier/DeletePanierItem/{id}
        [HttpDelete]
        [Route("[action]/{id}")]
        [ActionName("DeletePanierItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePanierItem(int id)
        {
            await dataRepository.DeletePanierItem(id);
            return NoContent();
        }
    }
}