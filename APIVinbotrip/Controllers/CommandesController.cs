using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class CommandesController : ControllerBase
        {
            private readonly DBVinotripContext _context;
            private readonly IDataRepository<Commande> dataRepository;

            public CommandesController(IDataRepository<Commande> dataRepo)

            {
                dataRepository = dataRepo;
            }


            // GET: api/Client
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
            {
                return dataRepository.GetAll();
            }

            // GET: api/Client/5
            [HttpGet]
            [Route("[action]/{id}")]
            [ActionName("GetById")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<Commande>> GetCommandeById(int id)
            {
                var commande = await dataRepository.GetByIdAsync(id);
                //var utilisateur = await _context.Client.FindAsync(id);
                if (commande == null)
                {
                    return NotFound();
                }
                return commande;
            }

            //[HttpGet]
            //[Route("[action]/{email}")]
            //[ActionName("GetByEmail")]
            //[ProducesResponseType(StatusCodes.Status200OK)]
            //[ProducesResponseType(StatusCodes.Status404NotFound)]
            //public async Task<ActionResult<Client>> GetClientByEmail(string email)
            //{
            //    var utilisateur = await dataRepository.GetByStringAsync(email);
            //    //var utilisateur = await _context.Client.FirstOrDefaultAsync(e => e.Mail.ToUpper() == email.ToUpper());
            //    if (utilisateur == null)
            //    {
            //        return NotFound();
            //    }
            //    return utilisateur;
            //}

            // PUT: api/Client/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> PutCommande(int id, Commande commande)
            {
                if (id != commande.IdCommande)
                {
                    return BadRequest();
                }
                var commandeToUpdate = await dataRepository.GetByIdAsync(id);
                if (commandeToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    await dataRepository.UpdateAsync(commandeToUpdate.Value, commande);
                    return NoContent();
                }
            }

            // POST: api/Client
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Commande>> PostCommande(Commande client)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await dataRepository.AddAsync(client);
                return CreatedAtAction("GetById", new { id = client.IdCommande }, client); // GetById : nom de l’action
            }

            // DELETE: api/Client/5
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> DeleteCommande(int id)
            {
                var commande = await dataRepository.GetByIdAsync(id);
                if (commande == null)
                {
                    return NotFound();
                }
                await dataRepository.DeleteAsync(commande.Value);
                return NoContent();
            }


            //private bool UtilisateurExists(int id)
            //{
            //    return _context.Client.Any(e => e.UtilisateurId == id);
            //}
        }
    }
