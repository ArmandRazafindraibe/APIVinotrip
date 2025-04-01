using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CategorieManager : ICategorieRepository
    {
        private readonly DBVinotripContext _context;

        public CategorieManager(DBVinotripContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategorieSejour>> GetAllCategorieSejourAsync()
        {
            return await _context.Categoriesejours.ToListAsync();
        }

        public async Task<IEnumerable<CategorieParticipant>> GetAllCategorieParticipantAsync()
        {
            return await _context.Categorieparticipants.ToListAsync();
        }

        public async Task<IEnumerable<CategorieVignoble>> GetAllCategorieVignobleAsync()
        {
            return await _context.Categorievignobles.ToListAsync();
        }

        public async Task<IEnumerable<Theme>> GetAllThemesAsync()
        {
            return await _context.Themes.ToListAsync();
        }
    }
}
