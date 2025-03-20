using Microsoft.AspNetCore.Mvc;
using APIVinotrip.Models.EntityFramework;

namespace APIVinotrip.Models.Repository
{
    public interface IDataRepository<TEntity>
    {

        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(int id);
        Task<ActionResult<TEntity>> GetByString(string str);
        Task  Add(TEntity entity);
        Task  Update(TEntity entityToUpdate, TEntity entity);
        Task  Delete(TEntity entity);
    }
}