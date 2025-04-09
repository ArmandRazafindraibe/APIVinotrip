using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class PanierManager:IPanierRepository<Panier>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public PanierManager() { }
        public PanierManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Panier>>> GetAll()
        {
            return vinotripDBContext.Paniers.ToList();
        }
        public  async Task<ActionResult<Panier>> GetById(int id)
        {
            return  vinotripDBContext.Paniers.FirstOrDefault(u => u.IdPanier == id);
        }

        public async Task<ActionResult<IEnumerable<DescriptionPanier>>> GetDescriptionsPanierById(int id)
        {
            return vinotripDBContext.Descriptionpaniers.Where(x=>x.IdPanier==id).ToList();
        }

        public async Task<ActionResult<DescriptionPanier>> GetOneDescriptionPanierById(int id)
        {
            return vinotripDBContext.Descriptionpaniers.FirstOrDefault(x=>x.IdPanier==id);
        }
        public  async Task<ActionResult<Panier>> GetByString(string vide)
        {
            return null;
        }
        public  async Task Add(Panier entity)
        {
             vinotripDBContext.Paniers.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task AddPanierDetail( DescriptionPanier desc)
        {
            vinotripDBContext.Descriptionpaniers.Add(desc);
            vinotripDBContext.SaveChanges();
        }
        public  async Task Update(Panier panier, Panier entity)
        {
            vinotripDBContext.Entry(panier).State = EntityState.Modified;
            panier.IdPanier = panier.IdPanier;
            panier.DateAjoutPanier = entity.DateAjoutPanier;
            panier.IdCodePromo= entity.IdCodePromo;
             vinotripDBContext.SaveChanges();
        }

        
        public async Task UpdateDetailPanier(DescriptionPanier desc, DescriptionPanier entity)
        {
            vinotripDBContext.Entry(desc).State = EntityState.Modified;
            desc.IdPanier = desc.IdPanier;
            desc.IdDescriptionPanier = desc.IdDescriptionPanier;
            desc.IdHebergement = entity.IdHebergement;
            desc.DateDebut = entity.DateDebut;
            desc.DateFin = entity.DateFin;
            desc.Offrir = entity.Offrir;
            desc.ECoffret = entity.ECoffret;
            desc.NbAdultes = entity.NbAdultes;
            desc.NbChambresDouble = entity.NbChambresDouble;
            desc.NbChambresSimple = entity.NbChambresSimple;
            desc.NbChambresTriple = entity.NbChambresTriple;
            desc.NbEnfants = entity.NbEnfants;
            desc.DisponibiliteHebergement = entity.DisponibiliteHebergement;
            vinotripDBContext.SaveChanges();
        }

        public async Task Delete(Panier panier)
        {
            vinotripDBContext.Paniers.Remove(panier);
             vinotripDBContext.SaveChanges();
        }
    }
}
