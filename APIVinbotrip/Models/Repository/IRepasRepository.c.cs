using Microsoft.AspNetCore.Mvc;
using APIVinotrip.Models.EntityFramework;

namespace APIVinotrip.Models.Repository
{
    public interface IRepasRepository<TEntity> : IDataRepository<TEntity>
    {

        Task<ActionResult<IEnumerable<Repas>>> GetAllRepasWithRestaurant();
    }
}