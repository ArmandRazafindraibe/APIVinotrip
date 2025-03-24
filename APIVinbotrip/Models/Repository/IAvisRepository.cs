using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Models.Repository
{
    public interface IAvisRepository<TEntity>: IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<Sejour>>> GetAllAvisWithSejours();
    }
}
