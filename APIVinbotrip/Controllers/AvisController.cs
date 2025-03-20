﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisController : ControllerBase
    {
        private readonly IDataRepository<Avis> dataRepository;

        public AvisController(IDataRepository<Avis> dataRepos)
        {
            dataRepository = dataRepos;
        }

        // GET: api/Aviss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avis>>> GetAviss()
        {
            return  dataRepository.GetAll();
        }

        // GET: api/Aviss/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avis>> GetAvisById(int id)
        {
            var avis = dataRepository.GetById(id);

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
        public async Task<ActionResult<Avis>> GetAvisByTitle(string title)
        {
            var avis = dataRepository.GetByString(title);

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
        public async Task<IActionResult> PutAvis(int id, Avis avis)
        {
            if (id != avis.IdAvis)
            {
                return BadRequest();
            }

            var userToUpdate = dataRepository.GetById(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                dataRepository.Update(userToUpdate.Value, avis);
                return NoContent();
            }
        }

            // POST: api/Aviss
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Avis>> PostAvis(Avis avis)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dataRepository.Add(avis);

            return CreatedAtAction("GetById", new { id = avis.IdAvis }, avis); // GetById : nom de l’action
        }

        // DELETE: api/Aviss/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAvis(int id)
        {
            var avis = dataRepository.GetById(id);
            if (avis == null)
            {
                return NotFound();
            }
            dataRepository.Delete(avis.Value);
            return NoContent();
        }

        //private bool AvisExists(int id)
        //{
        //    return _context.Aviss.Any(e => e.Idavis == id);
        //}
    }
}
