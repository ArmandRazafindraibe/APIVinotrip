using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("commande")]
    public partial class Commande
    {
        [Key]
        [Column("idcommande")]
        public int IdCommande { get; set; }

        [Column("idcodepromo")]
        [StringLength(20)]
        public int IdCodePromo { get; set; }

        [Column("idcb")]
        public int? IdCB { get; set; }

        [Column("idadressefacturation")]
        public int? IdAdresseFacturation { get; set; }

        [Column("idclientacheteur")]
        public int? IdClientAcheteur { get; set; }

        [Column("idclientbeneficiaire")]
        public int? IdClientBeneficiaire { get; set; }

        [Column("idadresselivraison")]
        public int? IdAdresseLivraison { get; set; }

        [Column("idpanier")]
        public int? IdPanier { get; set; }

        [Column("validationclient")]
        public bool ValidationClient { get; set; }

        [Column("codereduction")]
        [StringLength(20)]
        public string? codereduction { get; set; }

        [Column("etatcommande")]
        [StringLength(50)]
        public string? EtatCommande { get; set; }

        [Column("typepayementcommande")]
        [StringLength(50)]
        public string? TypePayementCommande { get; set; }

        [Column("datecommande", TypeName = "date")]
        public DateTime? DateCommande { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdClientAcheteur))]
        [InverseProperty(nameof(Client.Commandes))]
        public virtual Client? ClientAcheteur { get; set; }

        [ForeignKey(nameof(IdClientBeneficiaire))]
        [InverseProperty(nameof(Client.CommandesOfferts))]
        public virtual Client? ClientBeneficiaire { get; set; }

        [ForeignKey(nameof(IdCB))]
        [InverseProperty(nameof(CarteBancaire.Commandes))]
        public virtual CarteBancaire? CarteBancaire { get; set; }

        [ForeignKey(nameof(IdPanier))]
        [InverseProperty(nameof(Panier.Commandes))]
        public virtual Panier? PanierCommande { get; set; }

        [ForeignKey(nameof(IdAdresseLivraison))]
        [InverseProperty(nameof(Adresse.CommandesLivraison))]
        public virtual Adresse? AdresseLivraison { get; set; }

        [ForeignKey(nameof(IdAdresseFacturation))]
        [InverseProperty(nameof(Adresse.CommandesFacturation))]
        public virtual Adresse? AdresseFacturation { get; set; }

        [ForeignKey(nameof(IdCodePromo))]
        [InverseProperty(nameof(CodePromo.Commandes))]
        public virtual CodePromo? CodeReductionNavigation { get; set; }



        [InverseProperty(nameof(DescriptionCommande.Commande))]
        public virtual List<DescriptionCommande> DescriptionsCommande { get; set; } = new List<DescriptionCommande>();


    }
}
