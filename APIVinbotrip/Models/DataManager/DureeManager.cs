using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class DureeManager : IDataRepository<Duree>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public DureeManager() { }
        public DureeManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Duree>>> GetAll()
        {
            return vinotripDBContext.Durees.ToList();
        }
        public async Task<ActionResult<Duree>> GetById(int id)
        {
            return vinotripDBContext.Durees.FirstOrDefault(u => u.IdDuree == id);
        }
        public async Task<ActionResult<Duree>> GetByString(string mail)
        {
            return vinotripDBContext.Durees.FirstOrDefault(u => u.LibelleDuree.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Duree entity)
        {
            vinotripDBContext.Durees.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Duree duree, Duree entity)
        {
            vinotripDBContext.Entry(duree).State = EntityState.Modified;
            duree.IdDuree = entity.IdDuree;
            duree.LibelleDuree = entity.LibelleDuree;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Duree duree)
        {
            vinotripDBContext.Durees.Remove(duree);
            vinotripDBContext.SaveChanges();
        }
    }
}
