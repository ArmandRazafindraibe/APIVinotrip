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
    public class EtapesController : ControllerBase
    {
        private readonly DBVinotripContext _context;

        public EtapesController(DBVinotripContext context)
        {
            _context = context;
        }

        // GET: api/Etapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etape>>> GetEtapes()
        {
            return await _context.Etapes.ToListAsync();
        }

        // GET: api/Etapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etape>> GetEtape(int id)
        {
            var etape = await _context.Etapes.FindAsync(id);

            if (etape == null)
            {
                return NotFound();
            }

            return etape;
        }

        // PUT: api/Etapes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtape(int id, Etape etape)
        {
            if (id != etape.IdEtape)
            {
                return BadRequest();
            }

            _context.Entry(etape).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapeExists(id))
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

        // POST: api/Etapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etape>> PostEtape(Etape etape)
        {
            _context.Etapes.Add(etape);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtape", new { id = etape.IdEtape }, etape);
        }

        // DELETE: api/Etapes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtape(int id)
        {
            var etape = await _context.Etapes.FindAsync(id);
            if (etape == null)
            {
                return NotFound();
            }

            _context.Etapes.Remove(etape);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtapeExists(int id)
        {
            return _context.Etapes.Any(e => e.IdEtape == id);
        }
    }
}
