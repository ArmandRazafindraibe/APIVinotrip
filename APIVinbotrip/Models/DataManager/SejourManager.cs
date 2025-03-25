using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class SejourManager : ISejourRepository<Sejour>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public SejourManager() { }
        public SejourManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Sejour>>> GetAll()
        {
            return vinotripDBContext.Sejours.ToList();
        }
        public async Task<ActionResult<Sejour>> GetById(int id)
        {
            return  vinotripDBContext.Sejours.FirstOrDefault(u => u.Idsejour == id);
        }
        public  async Task<ActionResult<Sejour>> GetByString(string nomsejour)
        {
            return  vinotripDBContext.Sejours.FirstOrDefault(u => u.Titresejour.ToUpper() == nomsejour.ToUpper());
        }
        public async Task Add(Sejour entity)
        {
             vinotripDBContext.Sejours.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Sejour sejour, Sejour entity)
        {
            vinotripDBContext.Entry(sejour).State = EntityState.Modified;
            sejour.Idsejour = entity.Idsejour;
            sejour.Idcategorieparticipant = entity.Idcategorieparticipant;
            sejour.Idcategoriesejour = entity.Idcategoriesejour;
            sejour.Idcategorievignoble = entity.Idcategorievignoble;
            sejour.Idduree=entity.Idduree;
            sejour.Idlocalite = entity.Idlocalite;
            sejour.Idtheme = entity.Idtheme;
            sejour.Publie = entity.Publie;
            sejour.Descriptionsejour = entity.Descriptionsejour;
            sejour.Titresejour = entity.Titresejour;
            sejour.Prixsejour = entity.Prixsejour;
            sejour.Photosejour = entity.Photosejour;
            sejour.Nouveauprixsejour= entity.Nouveauprixsejour;

             vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Sejour sejour)
        {
            vinotripDBContext.Sejours.Remove(sejour);
             vinotripDBContext.SaveChanges();
        }

        public async Task<ActionResult<IEnumerable<Sejour>>> GetAllSejoursWithAvis()
        {
            var sejours = await vinotripDBContext.Sejours
               .Include(s => s.AvisNavigation)
               .ToListAsync();

            return sejours;
        }
    }
}
