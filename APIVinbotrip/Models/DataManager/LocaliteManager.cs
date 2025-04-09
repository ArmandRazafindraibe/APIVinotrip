using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class LocaliteManager : IDataRepository<Localite>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public LocaliteManager() { }
        public LocaliteManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Localite>>> GetAll()
        {
            return vinotripDBContext.Localites.ToList();
        }
        public async Task<ActionResult<Localite>> GetById(int id)
        {
            return vinotripDBContext.Localites.FirstOrDefault(u => u.IdLocalite == id);
        }
        public async Task<ActionResult<Localite>> GetByString(string mail)
        {
            return vinotripDBContext.Localites.FirstOrDefault(u => u.LibelleLocalite.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Localite entity)
        {
            vinotripDBContext.Localites.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Localite localite, Localite entity)
        {
            vinotripDBContext.Entry(localite).State = EntityState.Modified;
            localite.IdLocalite = localite.IdLocalite;
            localite.LibelleLocalite = entity.LibelleLocalite;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Localite localite)
        {
            vinotripDBContext.Localites.Remove(localite);
            vinotripDBContext.SaveChanges();
        }
    }
}
