using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.EntityFramework;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("COMMANDE")]
    public partial class Commande
    {
        [Key]
        [Column("idCommande")]
        public int IdCommande { get; set; }

        [Column("idCodePromo")]
        [StringLength(20)]
        public string? IdCodePromo { get; set; }

        [Column("idCB")]
        public int? IdCB { get; set; }

        [Column("idAdresseFacturation")]
        public int? IdAdresseFacturation { get; set; }

        [Column("idClientAcheteur")]
        public int? IdClientAcheteur { get; set; }

        [Column("idClientBeneficiaire")]
        public int? IdClientBeneficiaire { get; set; }

        [Column("idAdresseLivraison")]
        public int? IdAdresseLivraison { get; set; }

        [Column("idPanier")]
        public int? IdPanier { get; set; }

        [Column("validationClient")]
        public bool ValidationClient { get; set; }

        [Column("codeReduction")]
        [StringLength(20)]
        public string? CodeReduction { get; set; }

        [Column("etatCommande")]
        [StringLength(50)]
        public string? EtatCommande { get; set; }

        [Column("typePayementCommande")]
        [StringLength(50)]
        public string? TypePayementCommande { get; set; }

        [Column("dateCommande")]
        public DateTime? DateCommande { get; set; }

        // Navigation properties
        [ForeignKey(nameof(Client.IdClient))]
        [InverseProperty(nameof(Client.Commandes))]
        public virtual Client? ClientAcheteur { get; set; }

        [ForeignKey(nameof(Client.IdClient))]
        [InverseProperty(nameof(Client.CommandesOfferts))]
        public virtual Client? ClientBeneficiaire { get; set; }

        [ForeignKey(nameof(IdCB))]
        [InverseProperty(nameof(CarteBancaire.Commandes))]
        public virtual CarteBancaire? CarteBancaire { get; set; }

        [ForeignKey(nameof(IdPanier))]
        [InverseProperty(nameof(Panier.Commandes))]
        public virtual Panier? PanierCommande { get; set; }

        [ForeignKey(nameof(Adresse.IdAdresse))]
        [InverseProperty(nameof(Adresse.CommandesLivraison))]
        public virtual Adresse? AdresseLivraison { get; set; }

        [ForeignKey(nameof(Adresse.IdAdresse))]
        [InverseProperty(nameof(Adresse.CommandesFacturation))]
        public virtual Adresse? AdresseFacturation { get; set; }

        [ForeignKey(nameof(IdCodePromo))]
        [InverseProperty(nameof(CodePromo.Commandes))]
        public virtual CodePromo? CodeCodeReduction { get; set; }



        [InverseProperty(nameof(DescriptionCommande.Commande))]
        public virtual ICollection<DescriptionCommande> DescriptionsCommande { get; set; } = new List<DescriptionCommande>();


    }
}
