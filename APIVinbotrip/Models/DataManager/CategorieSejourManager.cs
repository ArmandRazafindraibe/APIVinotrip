using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CategorieSejourManager : IDataRepository<CategorieSejour>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public CategorieSejourManager() { }
        public CategorieSejourManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<CategorieSejour>>> GetAll()
        {
            return vinotripDBContext.Categoriesejours.ToList();
        }
        public async Task<ActionResult<CategorieSejour>> GetById(int id)
        {
            return vinotripDBContext.Categoriesejours.FirstOrDefault(u => u.IdCategorieSejour == id);
        }
        public async Task<ActionResult<CategorieSejour>> GetByString(string mail)
        {
            return vinotripDBContext.Categoriesejours.FirstOrDefault(u => u.LibelleCategoriesSejour.ToUpper() == mail.ToUpper());
        }
        public async Task Add(CategorieSejour entity)
        {
            vinotripDBContext.Categoriesejours.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(CategorieSejour categorieVignoble, CategorieSejour entity)
        {
            vinotripDBContext.Entry(categorieVignoble).State = EntityState.Modified;
            categorieVignoble.IdCategorieSejour = categorieVignoble.IdCategorieSejour;
            categorieVignoble.LibelleCategoriesSejour = entity.LibelleCategoriesSejour;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(CategorieSejour categorieVignoble)
        {
            vinotripDBContext.Categoriesejours.Remove(categorieVignoble);
            vinotripDBContext.SaveChanges();
        }
    }
}
