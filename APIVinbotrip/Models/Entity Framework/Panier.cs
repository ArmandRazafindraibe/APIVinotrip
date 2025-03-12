using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.Entity_Framework;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("PANIER")]
    public partial class Panier
    {
        [Key]
        [Column("idPanier")]
        public int IdPanier { get; set; }

        [Column("idCodePromo")]
        public int? IdCodePromo { get; set; }

        [Column("dateAjoutPanier")]
        public DateTime? DateAjoutPanier { get; set; }

        [InverseProperty(nameof(DescriptionPanier.Panier))]
        public virtual ICollection<DescriptionPanier> DescriptionsPanier { get; set; } = new List<DescriptionPanier>();

        [ForeignKey(nameof(IdCodePromo))]
        [InverseProperty(nameof(CodePromo.Paniers))]
        public virtual ICollection<CodePromo> CodesPromos { get; set; } = new List<CodePromo>();
    }
}
