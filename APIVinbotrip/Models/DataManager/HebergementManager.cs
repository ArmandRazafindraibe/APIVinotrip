using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class HebergementManager : IDataRepository<Hebergement>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public HebergementManager() { }
        public HebergementManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Hebergement>>> GetAll()
        {
            return vinotripDBContext.Hebergements.ToList();
        }
        public async Task<ActionResult<Hebergement>> GetById(int id)
        {
            return  vinotripDBContext.Hebergements.FirstOrDefault(u => u.IdHebergement == id);
        }
        public  async Task<ActionResult<Hebergement>> GetByString(string nomhebergement)
        {
            return  null;
        }
        public async Task Add(Hebergement entity)
        {
             vinotripDBContext.Hebergements.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Hebergement hebergement, Hebergement entity)
        {
            vinotripDBContext.Entry(hebergement).State = EntityState.Modified;
            hebergement.IdHebergement = entity.IdHebergement;
            hebergement.PrixHebergement = entity.PrixHebergement;
            hebergement.LienHebergement=entity.LienHebergement;
            hebergement.PhotoHebergement = entity.PhotoHebergement;
            hebergement.DescriptionHebergement = entity.DescriptionHebergement;
            vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Hebergement hebergement)
        {
            vinotripDBContext.Hebergements.Remove(hebergement);
            vinotripDBContext.SaveChanges();
        }
    }
}
