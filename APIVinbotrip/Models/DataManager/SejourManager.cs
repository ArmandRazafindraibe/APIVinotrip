using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class SejourManager : IDataRepository<Sejour>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public SejourManager() { }
        public SejourManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public ActionResult<IEnumerable<Sejour>> GetAll()
        {
            return vinotripDBContext.Sejours.ToList();
        }
        public ActionResult<Sejour> GetById(int id)
        {
            return  vinotripDBContext.Sejours.FirstOrDefault(u => u.Idsejour == id);
        }
        public  ActionResult<Sejour> GetByString(string nomsejour)
        {
            return  vinotripDBContext.Sejours.FirstOrDefault(u => u.Titresejour.ToUpper() == nomsejour.ToUpper());
        }
        public void Add(Sejour entity)
        {
             vinotripDBContext.Sejours.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public void Update(Sejour sejour, Sejour entity)
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
        public  void Delete(Sejour sejour)
        {
            vinotripDBContext.Sejours.Remove(sejour);
             vinotripDBContext.SaveChanges();
        }
    }
}
