using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class EtapeManager : IDataRepository<Etape>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public EtapeManager() { }
        public EtapeManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Etape>>> GetAll()
        {
            return vinotripDBContext.Etapes.ToList();
        }
        public async Task<ActionResult<Etape>> GetById(int id)
        {
            return  vinotripDBContext.Etapes.FirstOrDefault(u => u.IdEtape == id);
        }
        public  async Task<ActionResult<Etape>> GetByString(string nometape)
        {
            return  null;
        }
        public async Task Add(Etape entity)
        {
             vinotripDBContext.Etapes.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Etape etape, Etape entity)
        {
            vinotripDBContext.Entry(etape).State = EntityState.Modified;
            etape.IdEtape = entity.IdEtape;
            etape.IdSejour = entity.IdSejour;
            etape.IdHebergement = entity.IdHebergement;
            etape.TitreEtape = entity.TitreEtape;
            etape.VideoEtape = entity.VideoEtape;
            etape.URLEtape=entity.URLEtape;
            etape.PhotoEtape = entity.PhotoEtape;
            etape.DescriptionEtape = entity.DescriptionEtape;
            vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Etape etape)
        {
            vinotripDBContext.Etapes.Remove(etape);
            vinotripDBContext.SaveChanges();
        }
    }
}
