using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Models.Repository
{
    public interface ICommandeRepository<TEntity> : IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllCommandesByIdClient(int idclient);
        Task<ActionResult<TEntity>> GetCommandeByIdPanier(int idpanier);
        Task<ActionResult<DescriptionCommande>> GetDescriptionCommandeByIdDescription(int id);
        Task AddDescriptionCommande(DescriptionCommande commande);
        Task UpdateDescriptionCommande(DescriptionCommande desc, DescriptionCommande entity);


    }
}
