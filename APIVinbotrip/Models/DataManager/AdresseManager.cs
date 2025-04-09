using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class AdresseManager : IDataRepository<Adresse>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public AdresseManager() { }
        public AdresseManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAll()
        {
            return vinotripDBContext.Adresses.ToList();
        }
        public async Task<ActionResult<Adresse>> GetById(int id)
        {
            return  vinotripDBContext.Adresses.FirstOrDefault(u => u.IdAdresse == id);
        }
        public  async Task<ActionResult<Adresse>> GetByString(string nomadresse)
        {
            return  vinotripDBContext.Adresses.FirstOrDefault(u => u.NomAdresse.ToUpper() == nomadresse.ToUpper());
        }
        public async Task Add(Adresse entity)
        {
             vinotripDBContext.Adresses.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Adresse adresse, Adresse entity)
        {
            vinotripDBContext.Entry(adresse).State = EntityState.Modified;
            adresse.IdAdresse = adresse.IdAdresse;
            adresse.IdClient = entity.IdClient;
            adresse.IdPartenaire = entity.IdPartenaire;
            adresse.NumAdresse = entity.NumAdresse;
            adresse.CpAdresse = entity.CpAdresse;
            adresse.NomAdresse = entity.NomAdresse;
            adresse.NomAdresseDestinataire = entity.NomAdresseDestinataire;
            adresse.PrenomAdresseDestination = entity.PrenomAdresseDestination;
            adresse.VilleAdresse=entity.VilleAdresse;
            adresse.RueAdresse = entity.RueAdresse;
            adresse.PaysAdresse = entity.PaysAdresse;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Adresse adresse)
        {
            vinotripDBContext.Adresses.Remove(adresse);
             vinotripDBContext.SaveChanges();
        }
    }
}
