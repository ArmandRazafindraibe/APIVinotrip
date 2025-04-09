using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class ActiviteManager : IDataRepository<Activite>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public ActiviteManager() { }
        public ActiviteManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Activite>>> GetAll()
        {
            return vinotripDBContext.Activites.ToList();
        }
        public async Task<ActionResult<Activite>> GetById(int id)
        {
            return  vinotripDBContext.Activites.FirstOrDefault(u => u.IdActivite == id);
        }
        public  async Task<ActionResult<Activite>> GetByString(string nomactivite)
        {
            return  vinotripDBContext.Activites.FirstOrDefault(u => u.LibelleActivite.ToUpper() == nomactivite.ToUpper());
        }
        public async Task Add(Activite entity)
        {
             vinotripDBContext.Activites.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Activite activite, Activite entity)
        {
            vinotripDBContext.Entry(activite).State = EntityState.Modified;
            activite.IdActivite = activite.IdActivite;
            activite.PrixActivite = entity.PrixActivite;
            activite.LibelleActivite = entity.LibelleActivite;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Activite activite)
        {
            vinotripDBContext.Activites.Remove(activite);
             vinotripDBContext.SaveChanges();
        }
    }
}
