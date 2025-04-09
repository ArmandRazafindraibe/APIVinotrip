using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class RepasManager : IDataRepository<Repas>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public RepasManager() { }
        public RepasManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Repas>>> GetAll()
        {
            return vinotripDBContext.Repas.ToList();
        }
        public async Task<ActionResult<Repas>> GetById(int id)
        {
            return vinotripDBContext.Repas.FirstOrDefault(u => u.IdPartenaire == id);
        }
        public async Task<ActionResult<Repas>> GetByString(string vide)
        {
            return null;
        }
        public async Task Add(Repas entity)
        {
            vinotripDBContext.Repas.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Repas repas, Repas entity)
        {
            vinotripDBContext.Entry(repas).State = EntityState.Modified;
            repas.IdRepas = entity.IdRepas;
            repas.IdPartenaire = entity.IdPartenaire;
            repas.DescriptionRepas = entity.DescriptionRepas;
            repas.PhotoRepas = entity.PhotoRepas;
            repas.PrixRepas = entity.PrixRepas;

            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Repas repas)
        {
            vinotripDBContext.Repas.Remove(repas);
            vinotripDBContext.SaveChanges();
        }
    }
}
