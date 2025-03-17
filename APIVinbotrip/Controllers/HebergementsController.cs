using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HebergementsController : ControllerBase
    {
        private readonly DBVinotripContext _context;

        public HebergementsController(DBVinotripContext context)
        {
            _context = context;
        }

        // GET: api/Hebergements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hebergement>>> GetHebergements()
        {
            return await _context.Hebergements.ToListAsync();
        }

        // GET: api/Hebergements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hebergement>> GetHebergement(int id)
        {
            var hebergement = await _context.Hebergements.FindAsync(id);

            if (hebergement == null)
            {
                return NotFound();
            }

            return hebergement;
        }

        // PUT: api/Hebergements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHebergement(int id, Hebergement hebergement)
        {
            if (id != hebergement.IdHebergement)
            {
                return BadRequest();
            }

            _context.Entry(hebergement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HebergementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hebergements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hebergement>> PostHebergement(Hebergement hebergement)
        {
            _context.Hebergements.Add(hebergement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHebergement", new { id = hebergement.IdHebergement }, hebergement);
        }

        // DELETE: api/Hebergements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHebergement(int id)
        {
            var hebergement = await _context.Hebergements.FindAsync(id);
            if (hebergement == null)
            {
                return NotFound();
            }

            _context.Hebergements.Remove(hebergement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HebergementExists(int id)
        {
            return _context.Hebergements.Any(e => e.IdHebergement == id);
        }
    }
}
