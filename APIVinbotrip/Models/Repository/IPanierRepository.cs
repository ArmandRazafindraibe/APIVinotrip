using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Models.Repository
{
    public interface IPanierRepository<TEntity> : IDataRepository<TEntity>
    {
        Task AddPanierDetail(DescriptionPanier desc);
        Task UpdateDetailPanier(DescriptionPanier desc, DescriptionPanier entity);
        Task<ActionResult<IEnumerable<DescriptionPanier>>> GetDescriptionsPanierById(int id);
        Task<ActionResult<DescriptionPanier>> GetOneDescriptionPanierById(int id);
        Task<ActionResult<IEnumerable<DescriptionPanier>>> GetAllDescriptionPanierDetail(int idPanier);
        Task DeletePanierItem(int idDescriptionPanier);
    }
}
