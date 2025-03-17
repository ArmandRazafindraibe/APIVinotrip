using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("codepromo")]
    public partial class CodePromo
    {
        [Key]
        [Column("idcodepromo")]
        public int IdCodePromo { get; set; }

        [Column("libellecodepromo")]
        [StringLength(15)]
        public string? LibelleCodePromo { get; set; }

        [Column("reduction")]
        public int? Reduction { get; set; }

        [InverseProperty(nameof(Panier.CodesPromos))]
        public virtual ICollection<Panier> Paniers { get; set; } = new List<Panier>();

        [InverseProperty(nameof(Commande.CodeReductionNavigation))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}


