using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class HebergementManager : IHebergementRepository
    {
        private readonly DBVinotripContext _context;

        public HebergementManager(DBVinotripContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hebergement>> GetAllAsync()
        {
            return await _context.Hebergements.ToListAsync();
        }

        public async Task<Hebergement> GetByIdAsync(int id)
        {
            return await _context.Hebergements.FindAsync(id);
        }

        public async Task<Hebergement> GetByIdWithHotelAsync(int id)
        {
            return await _context.Hebergements
                .Include(h => h.HebergementHotel)
                .FirstOrDefaultAsync(h => h.IdHebergement == id);
        }

        public async Task<IEnumerable<Visite>> GetAllVisitesAsync()
        {
            return await _context.Visites.ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<IEnumerable<Cave>> GetAllCavesAsync()
        {
            return await _context.Caves.ToListAsync();
        }

        public async Task<Hotel> GetHotelByHebergementIdAsync(int idHebergement)
        {
            return await _context.Hebergements
                .Where(h => h.IdHebergement == idHebergement)
                .Select(h => h.HebergementHotel)
                .FirstOrDefaultAsync();
        }
    }

    public class EtapeRepository : IEtapeRepository
    {
        private readonly DBVinotripContext _context;

        public EtapeRepository(DBVinotripContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Etape>> GetAllAsync()
        {
            return await _context.Etapes.ToListAsync();
        }

        public async Task<IEnumerable<Etape>> GetBySejourIdAsync(int idSejour)
        {
            return await _context.Etapes
                .Where(e => e.IdSejour == idSejour)
                .ToListAsync();
        }

        public async Task<Etape> GetByIdAsync(int id)
        {
            return await _context.Etapes.FindAsync(id);
        }

        public async Task<Etape> GetByIdAndSejourAsync(int idEtape, int idSejour)
        {
            return await _context.Etapes
                .FirstOrDefaultAsync(e => e.IdEtape == idEtape && e.IdSejour == idSejour);
        }

        public async Task AddAsync(Etape etape)
        {
            await _context.Etapes.AddAsync(etape);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Etape etape)
        {
            _context.Etapes.Update(etape);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHebergementAsync(int idEtape, int idHebergement)
        {
            var etape = await _context.Etapes.FindAsync(idEtape);
            if (etape != null)
            {
                etape.IdHebergement = idHebergement;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var etape = await _context.Etapes.FindAsync(id);
            if (etape != null)
            {
                _context.Etapes.Remove(etape);
                await _context.SaveChangesAsync();
            }
        }
    }

   
    }
