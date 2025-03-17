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
    public class SejoursController : ControllerBase
    {
        private readonly DBVinotripContext _context;

        public SejoursController(DBVinotripContext context)
        {
            _context = context;
        }

        // GET: api/Sejours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sejour>>> GetSejours()
        {
            return await _context.Sejours.ToListAsync();
        }

        // GET: api/Sejours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sejour>> GetSejour(int id)
        {
            var sejour = await _context.Sejours.FindAsync(id);

            if (sejour == null)
            {
                return NotFound();
            }

            return sejour;
        }

        // PUT: api/Sejours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSejour(int id, Sejour sejour)
        {
            if (id != sejour.Idsejour)
            {
                return BadRequest();
            }

            _context.Entry(sejour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SejourExists(id))
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

        // POST: api/Sejours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sejour>> PostSejour(Sejour sejour)
        {
            _context.Sejours.Add(sejour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSejour", new { id = sejour.Idsejour }, sejour);
        }

        // DELETE: api/Sejours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSejour(int id)
        {
            var sejour = await _context.Sejours.FindAsync(id);
            if (sejour == null)
            {
                return NotFound();
            }

            _context.Sejours.Remove(sejour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SejourExists(int id)
        {
            return _context.Sejours.Any(e => e.Idsejour == id);
        }
    }
}
