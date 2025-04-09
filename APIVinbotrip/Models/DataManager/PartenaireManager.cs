using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class PartenaireManager : IDataRepository<Partenaire>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public PartenaireManager() { }
        public PartenaireManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Partenaire>>> GetAll()
        {
            return vinotripDBContext.Partenaires.ToList();
        }
        public async Task<ActionResult<Partenaire>> GetById(int id)
        {
            return vinotripDBContext.Partenaires.FirstOrDefault(u => u.IdPartenaire == id);
        }
        public async Task<ActionResult<Partenaire>> GetByString(string vide)
        {
            return null;
        }
        public async Task Add(Partenaire entity)
        {
            vinotripDBContext.Partenaires.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Partenaire partenaire, Partenaire entity)
        {
            vinotripDBContext.Entry(partenaire).State = EntityState.Modified;
            partenaire.IdPartenaire = partenaire.IdPartenaire;
            partenaire.NomPartenaire = entity.NomPartenaire;
            partenaire.MailPartenaire = entity.MailPartenaire;
            partenaire.TelPartenaire = entity.TelPartenaire;

            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Partenaire partenaire)
        {
            vinotripDBContext.Partenaires.Remove(partenaire);
            vinotripDBContext.SaveChanges();
        }
    }
}
