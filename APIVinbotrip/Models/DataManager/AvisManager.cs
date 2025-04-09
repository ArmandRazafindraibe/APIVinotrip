using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class AvisManager : IDataRepository<Avis>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public AvisManager() { }
        public AvisManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Avis>>> GetAll()
        {
            return vinotripDBContext.Avis.ToList();
        }
        public async Task<ActionResult<Avis>> GetById(int id)
        {
            return vinotripDBContext.Avis.FirstOrDefault(u => u.IdAvis == id);
        }
        public async Task<ActionResult<Avis>> GetByString(string nomavis)
        {
            return vinotripDBContext.Avis.FirstOrDefault(u => u.TitreAvis.ToUpper() == nomavis.ToUpper());
        }
        public async Task Add(Avis entity)
        {
            vinotripDBContext.Avis.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Avis avis, Avis entity)
        {
            vinotripDBContext.Entry(avis).State = EntityState.Modified;
            avis.IdAvis = avis.IdAvis;
            avis.DateAvis = entity.DateAvis;
            avis.NoteAvis = entity.NoteAvis;
            avis.PhotoAvis = entity.PhotoAvis;
            avis.DescriptionAvis = entity.DescriptionAvis;
            avis.TitreAvis = entity.TitreAvis;
            avis.IdClient = entity.IdClient;
            avis.IdSejour = entity.IdSejour;

            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Avis avis)
        {
            vinotripDBContext.Avis.Remove(avis);
            vinotripDBContext.SaveChanges();
        }


    }
}
    

