using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Models.Repository
{
    public interface ISejourRepository<TEntity>: IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<Sejour>>> GetAllSejoursWithAvis();
        Task<ActionResult<IEnumerable<Sejour>>> GetAllSejoursWithRoutes(int idroute);
    }
}
