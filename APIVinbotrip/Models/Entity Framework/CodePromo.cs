using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.Entity_Framework;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("CODEPROMO")]
    public partial class CodePromo
    {
        [Key]
        [Column("idCodePromo")]
        public int IdCodePromo { get; set; }

        [Column("libelleCodePromo")]
        [StringLength(15)]
        public string? LibelleCodePromo { get; set; }

        [Column("reduction")]
        public int? Reduction { get; set; }

        [InverseProperty(nameof(Panier.CodesPromos))]
        public virtual ICollection<Panier> Paniers { get; set; } = new List<Panier>();

        [InverseProperty(nameof(Commande.CodeReduction))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}


