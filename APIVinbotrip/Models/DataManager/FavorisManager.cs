using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class FavorisManager : IDataRepository<Favoris>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public FavorisManager() { }
        public FavorisManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Favoris>>> GetAll()
        {
            return vinotripDBContext.Favoris.ToList();
        }

        public async Task<ActionResult<Favoris>> GetById(int id)
        {
            return  vinotripDBContext.Favoris.FirstOrDefault(u => u.IdSejour == id);
        }
        public async Task<ActionResult<Favoris>> GetByString(string titresejour)
        {
            List<Sejour> sejours = vinotripDBContext.Sejours.ToList();
            Favoris favoris = new Favoris();
            foreach (Sejour sejour in sejours)
            {
                if (sejour.Titresejour.ToLower() == titresejour.ToLower())
                {
                    favoris= vinotripDBContext.Favoris.FirstOrDefault(lefav => lefav.IdSejour == sejour.Idsejour);
                }
            }
            return favoris;
        }
        public async Task Add(Favoris entity)
        {
             vinotripDBContext.Favoris.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public async Task Update(Favoris favoris, Favoris entity)
        {
            vinotripDBContext.Entry(favoris).State = EntityState.Modified;
            favoris.IdSejour = entity.IdSejour;
             vinotripDBContext.SaveChanges();
        }
        public  async Task Delete(Favoris favoris)
        {
            vinotripDBContext.Favoris.Remove(favoris);
             vinotripDBContext.SaveChanges();
        }
    }
}
