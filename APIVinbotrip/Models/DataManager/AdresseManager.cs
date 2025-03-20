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
        public ActionResult<IEnumerable<Adresse>> GetAll()
        {
            return vinotripDBContext.Adresses.ToList();
        }
        public ActionResult<Adresse> GetById(int id)
        {
            return  vinotripDBContext.Adresses.FirstOrDefault(u => u.IdAdresse == id);
        }
        public  ActionResult<Adresse> GetByString(string nomadresse)
        {
            return  vinotripDBContext.Adresses.FirstOrDefault(u => u.NomAdresse.ToUpper() == nomadresse.ToUpper());
        }
        public void Add(Adresse entity)
        {
             vinotripDBContext.Adresses.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public void Update(Adresse adresse, Adresse entity)
        {
            vinotripDBContext.Entry(adresse).State = EntityState.Modified;
            adresse.IdAdresse = entity.IdAdresse;
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
        public  void Delete(Adresse adresse)
        {
            vinotripDBContext.Adresses.Remove(adresse);
             vinotripDBContext.SaveChanges();
        }
    }
}
