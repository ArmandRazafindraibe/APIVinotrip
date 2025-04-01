using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class SejourManager : ISejourRepository
    {
        private readonly DBVinotripContext _context;

        public SejourManager(DBVinotripContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sejour>> GetAllAsync()
        {
            return await _context.Sejours
                .OrderBy(s => s.Idsejour)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sejour>> GetAllPublishedAsync()
        {
            return await _context.Sejours
                .Where(s => s.Publie)
                .OrderBy(s => s.Idsejour)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sejour>> GetAllUnpublishedAsync()
        {
            return await _context.Sejours
                .Where(s => !s.Publie)
                .OrderBy(s => s.Idsejour)
                .ToListAsync();
        }

        public async Task<Sejour> GetByIdAsync(int id)
        {
            return await _context.Sejours
                .Include(s => s.Photos)
                .FirstOrDefaultAsync(s => s.Idsejour == id);
        }

        public async Task<Sejour> GetByIdWithEtapesAsync(int id)
        {
            return await _context.Sejours
                .Include(s => s.Etapes)
                    .ThenInclude(e => e.Hebergement)
                        .ThenInclude(h => h.HebergementHotel)
                .FirstOrDefaultAsync(s => s.Idsejour == id);
        }

        public async Task<Sejour> GetRandomAsync()
        {
            return await _context.Sejours
                .OrderBy(s => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sejour>> GetRelatedSejoursAsync(int idCategorieVignoble, int idCategorieSejour, int currentSejourId, int limit)
        {
            return await _context.Sejours
                .Where(s => s.Idcategorievignoble == idCategorieVignoble
                    && s.Idcategoriesejour == idCategorieSejour
                    && s.Idsejour != currentSejourId
                    && s.Publie)
                .Take(limit)
                .ToListAsync();
        }

        public async Task AddAsync(Sejour sejour)
        {
            await _context.Sejours.AddAsync(sejour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sejour sejour)
        {
            _context.Sejours.Update(sejour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sejour = await _context.Sejours.FindAsync(id);
            if (sejour != null)
            {
                _context.Sejours.Remove(sejour);
                await _context.SaveChangesAsync();
            }
        }
    }
}
