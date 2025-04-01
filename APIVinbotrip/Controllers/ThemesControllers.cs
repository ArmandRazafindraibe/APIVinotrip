using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.DataManager;
using APIVinotrip.Models.Repository;

namespace APIVinotrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IDataRepository<Theme> dataRepository;

        public ThemesController(IDataRepository<Theme> dataRepos)
        {
             dataRepository = dataRepos;
        }

        // GET: api/Themes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
        {
            return await dataRepository.GetAll();
        }

        // GET: api/Themes/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Theme>> GetThemeById(int id)
        {
            var theme =  await dataRepository.GetById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return  theme;
        }

        // GET: api/Themes/5
        [HttpGet]
        [Route("[action]/{title}")]
        [ActionName("GetThemeByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Theme>> GetThemeByTitle(string title)
        {
            var theme = await dataRepository.GetByString(title);

            if (theme == null)
            {
                return NotFound();
            }

            return  theme;
        }

        // PUT: api/Themes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTheme(int id, Theme theme)
        {
            if (id != theme.IdTheme)
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
               await  dataRepository.Update(userToUpdate.Value, theme);
                return NoContent();
            }
        }

            // POST: api/Themes
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Theme>> PostTheme(Theme theme)
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.Add(theme);

            return CreatedAtAction("GetById", new { id = theme.IdTheme }, theme); // GetById : nom de l’action
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTheme(int id)
        {
            var theme = await dataRepository.GetById(id);
            if (theme == null)
            {
                return NotFound();
            }
            await dataRepository.Delete(theme.Value);
            return NoContent();
        }

        //private bool ThemeExists(int id)
        //{
        //    return _context.Themes.Any(e => e.Idtheme == id);
        //}
    }
}
