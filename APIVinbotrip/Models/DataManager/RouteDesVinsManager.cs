using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class RouteDesVinsManager:IDataRepository<RouteDesVins>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public RouteDesVinsManager() { }
        public RouteDesVinsManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public ActionResult<IEnumerable<RouteDesVins>> GetAll()
        {
            return vinotripDBContext.RouteDesVins.ToList();
        }
        public  ActionResult<RouteDesVins> GetById(int id)
        {
            return  vinotripDBContext.RouteDesVins.FirstOrDefault(u => u.IdRoute == id);
        }
        public  ActionResult<RouteDesVins> GetByString(string lib)
        {
            return  vinotripDBContext.RouteDesVins.FirstOrDefault(u => u.LibRoute.ToUpper() == lib.ToUpper());
        }
        public  void Add(RouteDesVins entity)
        {
             vinotripDBContext.RouteDesVins.Add(entity);
             vinotripDBContext.SaveChanges();
        }
        public  void Update(RouteDesVins routeDesVins, RouteDesVins entity)
        {
            vinotripDBContext.Entry(routeDesVins).State = EntityState.Modified;
            routeDesVins.IdRoute = entity.IdRoute;
            routeDesVins.LibRoute = entity.LibRoute;
            routeDesVins.PhotoRoute = entity.PhotoRoute;
            routeDesVins.DescriptionRoute = entity.DescriptionRoute;         
            vinotripDBContext.SaveChanges();
        }
        public  void Delete(RouteDesVins routeDesVins)
        {
            vinotripDBContext.RouteDesVins.Remove(routeDesVins);
            vinotripDBContext.SaveChanges();
        }
    }
}
