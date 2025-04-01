using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class VisiteManager : IDataRepository<Visite>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public VisiteManager() { }
        public VisiteManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Visite>>> GetAll()
        {
            return vinotripDBContext.Visites.ToList();
        }
        public async Task<ActionResult<Visite>> GetById(int id)
        {
            return  vinotripDBContext.Visites.FirstOrDefault(u => u.IdVisite == id);
        }
        public  async Task<ActionResult<Visite>> GetByString(string nomvisite)
        {
            return null;
        }
        public async Task Add(Visite entity)
        {
             vinotripDBContext.Visites.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Visite visite, Visite entity)
        {
            vinotripDBContext.Entry(visite).State = EntityState.Modified;
            visite.IdVisite = entity.IdVisite;
            visite.LienVisite = entity.LienVisite;
            visite.PhotoVisite= entity.PhotoVisite;
            visite.DescriptionVisite= entity.DescriptionVisite;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Visite visite)
        {
            vinotripDBContext.Visites.Remove(visite);
             vinotripDBContext.SaveChanges();
        }
    }
}
