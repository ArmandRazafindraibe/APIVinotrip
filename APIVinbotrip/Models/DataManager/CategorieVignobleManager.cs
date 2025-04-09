using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CategorieVignobleManager : IDataRepository<CategorieVignoble>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public CategorieVignobleManager() { }
        public CategorieVignobleManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<CategorieVignoble>>> GetAll()
        {
            return vinotripDBContext.Categorievignobles.ToList();
        }
        public async Task<ActionResult<CategorieVignoble>> GetById(int id)
        {
            return vinotripDBContext.Categorievignobles.FirstOrDefault(u => u.IdCategorieVignoble == id);
        }
        public async Task<ActionResult<CategorieVignoble>> GetByString(string mail)
        {
            return vinotripDBContext.Categorievignobles.FirstOrDefault(u => u.LibelleCategorieVignoble.ToUpper() == mail.ToUpper());
        }
        public async Task Add(CategorieVignoble entity)
        {
            vinotripDBContext.Categorievignobles.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(CategorieVignoble categorieVignoble, CategorieVignoble entity)
        {
            vinotripDBContext.Entry(categorieVignoble).State = EntityState.Modified;
            categorieVignoble.IdCategorieVignoble = categorieVignoble.IdCategorieVignoble;
            categorieVignoble.LibelleCategorieVignoble = entity.LibelleCategorieVignoble;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(CategorieVignoble categorieVignoble)
        {
            vinotripDBContext.Categorievignobles.Remove(categorieVignoble);
            vinotripDBContext.SaveChanges();
        }
    }
}
