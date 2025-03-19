using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CommandeManager : IDataRepository<Commande>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public CommandeManager() { }
        public CommandeManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public ActionResult<IEnumerable<Commande>> GetAll()
        {
            return vinotripDBContext.Commandes.ToList();
        }
        public async Task<ActionResult<Commande>> GetByIdAsync(int id)
        {
            return await vinotripDBContext.Commandes.FirstOrDefaultAsync(u => u.IdCommande == id);
        }
        public async Task<ActionResult<Commande>> GetByStringAsync(string mail)
        {
            return await vinotripDBContext.Commandes.FirstOrDefaultAsync(u=>u.EtatCommande == mail);
        }
        public async Task AddAsync(Commande entity)
        {
            await vinotripDBContext.Commandes.AddAsync(entity);
            await vinotripDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Commande commande, Commande entity)
        {
            vinotripDBContext.Entry(commande).State = EntityState.Modified;
            commande.IdCommande = entity.IdCommande;
            commande.IdCodePromo = entity.IdCodePromo;
            commande.IdCB = entity.IdCB;
            commande.IdAdresseFacturation = entity.IdAdresseFacturation;
            commande.IdClientAcheteur = entity.IdClientAcheteur;
            commande.IdClientBeneficiaire = entity.IdClientBeneficiaire;
            commande.IdAdresseLivraison = entity.IdAdresseLivraison;
            commande.IdPanier = entity.IdPanier;
            commande.ValidationClient = entity.ValidationClient;
            commande.codereduction = entity.codereduction;
            commande.EtatCommande = entity.EtatCommande;
            commande.TypePayementCommande = entity.TypePayementCommande;
            commande.DateCommande = entity.DateCommande;

            
            commande.ClientAcheteur = entity.ClientAcheteur;
            commande.ClientBeneficiaire = entity.ClientBeneficiaire;
            commande.CarteBancaire = entity.CarteBancaire;
            commande.PanierCommande = entity.PanierCommande;
            commande.AdresseLivraison = entity.AdresseLivraison;
            commande.AdresseFacturation = entity.AdresseFacturation;
            commande.CodeReductionNavigation = entity.CodeReductionNavigation;
            commande.DescriptionsCommande = entity.DescriptionsCommande;

            await vinotripDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Commande commande)
        {
            vinotripDBContext.Commandes.Remove(commande);
            await vinotripDBContext.SaveChangesAsync();
        }
    }
}
