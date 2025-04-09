using APIVinotrip.Models.EntityFramework;
using APIVinotrip.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.DataManager
{
    public class CommandeManager : ICommandeRepository<Commande>
    {
        readonly DBVinotripContext? vinotripDBContext;
        public CommandeManager() { }
        public CommandeManager(DBVinotripContext context)
        {
            vinotripDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Commande>>> GetAll()
        {
            return vinotripDBContext.Commandes.ToList();
        }
        public  async Task<ActionResult<Commande>> GetById(int id)
        {
            return  vinotripDBContext.Commandes.FirstOrDefault(u => u.IdCommande == id);
        }

        public async Task<ActionResult<IEnumerable<Commande>>> GetAllCommandesByIdClient(int id)
        {
            return vinotripDBContext.Commandes.Where(u => u.IdClientAcheteur == id).ToList();
        }

        public async Task<ActionResult<Commande>> GetCommandeByIdPanier(int id)
        {
            return vinotripDBContext.Commandes.FirstOrDefault(u => u.IdPanier == id);
        }
        public async Task<ActionResult<DescriptionCommande>> GetDescriptionCommandeByIdDescription(int id)
        {
            return vinotripDBContext.Descriptioncommandes.FirstOrDefault(u => u.IdCommande == id);
        }


        public  async Task<ActionResult<Commande>> GetByString(string etat)
        {
            return  vinotripDBContext.Commandes.FirstOrDefault(u=>u.EtatCommande.ToLower() == etat.ToLower());
        }
        public async  Task Add(Commande entity)
        {
             vinotripDBContext.Commandes.Add(entity);
             vinotripDBContext.SaveChanges();
        }

        public async Task AddDescriptionCommande(DescriptionCommande entity)
        {
            vinotripDBContext.Descriptioncommandes.Add(entity);
            vinotripDBContext.SaveChanges();
        }

        public async  Task Update(Commande commande, Commande entity)
        {
            vinotripDBContext.Entry(commande).State = EntityState.Modified;
            commande.IdCommande = commande.IdCommande;
            commande.IdCodePromo = commande.IdCodePromo;
            commande.IdCB = entity.IdCB;
            commande.IdAdresseFacturation = entity.IdAdresseFacturation;
            commande.IdClientAcheteur = commande.IdClientAcheteur;
            commande.IdClientBeneficiaire = entity.IdClientBeneficiaire;
            commande.IdAdresseLivraison = entity.IdAdresseLivraison;
            commande.IdPanier = commande.IdPanier;
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

             vinotripDBContext.SaveChanges();
        }

        public async Task UpdateDescriptionCommande(DescriptionCommande desccommande, DescriptionCommande entity)
        {
            vinotripDBContext.Entry(desccommande).State = EntityState.Modified;
            desccommande.IdCommande = desccommande.IdCommande;
            desccommande.IdHebergement = entity.IdHebergement;
            desccommande.IdCB = entity.IdCB;
            desccommande.ECoffret= entity.ECoffret;
            desccommande.DateDebut = entity.DateDebut;
            desccommande.DateFin= entity.DateFin;
            desccommande.IdSejour = entity.IdSejour;
            desccommande.NbChambresDouble = entity.NbChambresDouble;
            desccommande.NbChambresSimple = entity.NbChambresSimple;
            desccommande.NbChambresTriple = entity.NbChambresTriple;
            desccommande.NbAdultes= entity.NbAdultes;
            desccommande.NbEnfants= entity.NbEnfants;
            desccommande.Offrir= entity.Offrir;
            desccommande.Quantite= entity.Quantite;
            desccommande.ValidationClient = entity.ValidationClient;
           

            vinotripDBContext.SaveChanges();
        }
        public async  Task Delete(Commande commande)
        {
            vinotripDBContext.Commandes.Remove(commande);
             vinotripDBContext.SaveChanges();
        }
    }
}
