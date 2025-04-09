using Microsoft.AspNetCore.Mvc;
using APIVinotrip.Models.EntityFramework;

namespace APIVinotrip.Models.Repository
{
    public interface IEtapeRepository<TEntity>:IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<Etape>>> GetAllEtapeWithActivite();
    }
}