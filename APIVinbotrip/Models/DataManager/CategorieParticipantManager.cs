using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CategorieParticipantManager : IDataRepository<CategorieParticipant>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public CategorieParticipantManager() { }
        public CategorieParticipantManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<CategorieParticipant>>> GetAll()
        {
            return vinotripDBContext.Categorieparticipants.ToList();
        }
        public async Task<ActionResult<CategorieParticipant>> GetById(int id)
        {
            return vinotripDBContext.Categorieparticipants.FirstOrDefault(u => u.IdCategorieParticipant == id);
        }
        public async Task<ActionResult<CategorieParticipant>> GetByString(string mail)
        {
            return vinotripDBContext.Categorieparticipants.FirstOrDefault(u => u.LibelleCategorieParticipant.ToUpper() == mail.ToUpper());
        }
        public async Task Add(CategorieParticipant entity)
        {
            vinotripDBContext.Categorieparticipants.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(CategorieParticipant categorieVignoble, CategorieParticipant entity)
        {
            vinotripDBContext.Entry(categorieVignoble).State = EntityState.Modified;
            categorieVignoble.IdCategorieParticipant = categorieVignoble.IdCategorieParticipant;
            categorieVignoble.LibelleCategorieParticipant = entity.LibelleCategorieParticipant;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(CategorieParticipant categorieVignoble)
        {
            vinotripDBContext.Categorieparticipants.Remove(categorieVignoble);
            vinotripDBContext.SaveChanges();
        }
    }
}
