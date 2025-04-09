using APIVinotrip.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace APIVinotrip.Models.Repository
{
    public interface IPanierRepository<TEntity> : IDataRepository<TEntity>
    {
        Task AddPanierDetail(DescriptionPanier desc);
        Task UpdateDetailPanier(DescriptionPanier desc, DescriptionPanier entity);
        Task<ActionResult<DescriptionPanier>> GetDescriptionPanierById(int id);
    }
}
