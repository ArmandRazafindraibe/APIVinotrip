using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("panier")]
    public partial class Panier
    {
        [Key]
        [Column("idpanier")]
        public int IdPanier { get; set; }

        [Column("idcodepromo")]
        public int? IdCodePromo { get; set; }

        [Column("dateajoutpanier")]
        public DateTime? DateAjoutPanier { get; set; }

        [InverseProperty(nameof(DescriptionPanier.Panier))]
        public virtual List<DescriptionPanier> DescriptionsPanier { get; set; } = new List<DescriptionPanier>();

        [ForeignKey(nameof(IdCodePromo))]
        [InverseProperty(nameof(CodePromo.Paniers))]
        public virtual CodePromo? CodesPromos { get; set; }

        [InverseProperty(nameof(Commande.PanierCommande))]
        public virtual List<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
