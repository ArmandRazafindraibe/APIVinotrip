using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class ReservationHotel : IDataRepository<Hotel>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public ReservationHotel() { }
        public ReservationHotel(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAll()
        {
            return vinotripDBContext.Hotels.ToList();
        }
        public async Task<ActionResult<Hotel>> GetById(int id)
        {
            return vinotripDBContext.Hotels.FirstOrDefault(u => u.IdPartenaire == id);
        }
        public async Task<ActionResult<Hotel>> GetByString(string mail)
        {
            return vinotripDBContext.Hotels.FirstOrDefault(u => u.NomPartenaire.ToUpper() == mail.ToUpper());
        }
        public async Task Add(Hotel entity)
        {
            vinotripDBContext.Hotels.Add(entity);
            vinotripDBContext.SaveChanges();
        }
        public async Task Update(Hotel hotel, Hotel entity)
        {
            vinotripDBContext.Entry(hotel).State = EntityState.Modified;
            hotel.IdPartenaire = entity.IdPartenaire;
            hotel.NomPartenaire = entity.NomPartenaire;
            hotel.TelPartenaire = entity.TelPartenaire;
            hotel.MailPartenaire = entity.MailPartenaire;
            vinotripDBContext.SaveChanges();
        }
        public async Task Delete(Hotel hotel)
        {
            vinotripDBContext.Hotels.Remove(hotel);
            vinotripDBContext.SaveChanges();
        }
    }
}
