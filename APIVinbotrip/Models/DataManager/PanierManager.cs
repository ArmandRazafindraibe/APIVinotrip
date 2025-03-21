using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class PanierManager:IDataRepository<Panier>
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
        public  async Task<ActionResult<Panier>> GetByString(string vide)
        {
            return null;
        }
        public  async Task Add(Panier entity)
        {
             vinotripDBContext.Paniers.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public  async Task Update(Panier panier, Panier entity)
        {
            vinotripDBContext.Entry(panier).State = EntityState.Modified;
            panier.IdPanier = entity.IdPanier;
            panier.DateAjoutPanier = entity.DateAjoutPanier;
            panier.IdCodePromo= entity.IdCodePromo;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Panier panier)
        {
            vinotripDBContext.Paniers.Remove(panier);
             vinotripDBContext.SaveChanges();
        }
    }
}
