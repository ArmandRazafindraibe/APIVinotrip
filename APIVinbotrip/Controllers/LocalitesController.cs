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
    public class LocalitesController : ControllerBase
    {
        private readonly DBVinotripContext _context;

        public LocalitesController(DBVinotripContext context)
        {
            _context = context;
        }

        // GET: api/Localites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localite>>> GetLocalites()
        {
            return await _context.Localites.ToListAsync();
        }

        // GET: api/Localites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localite>> GetLocalite(int id)
        {
            var localite = await _context.Localites.FindAsync(id);

            if (localite == null)
            {
                return NotFound();
            }

            return localite;
        }

        // PUT: api/Localites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalite(int id, Localite localite)
        {
            if (id != localite.IdLocalite)
            {
                return BadRequest();
            }

            _context.Entry(localite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaliteExists(id))
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

        // POST: api/Localites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Localite>> PostLocalite(Localite localite)
        {
            _context.Localites.Add(localite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalite", new { id = localite.IdLocalite }, localite);
        }

        // DELETE: api/Localites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalite(int id)
        {
            var localite = await _context.Localites.FindAsync(id);
            if (localite == null)
            {
                return NotFound();
            }

            _context.Localites.Remove(localite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaliteExists(int id)
        {
            return _context.Localites.Any(e => e.IdLocalite == id);
        }
    }
}
