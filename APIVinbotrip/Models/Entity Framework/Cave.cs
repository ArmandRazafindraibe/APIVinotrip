using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("CAVE")]
    public partial class Cave
    {
        [Key]
        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Column("idTypeDegustation")]
        public int? IdTypeDegustation { get; set; }

        [Column("nomPartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailPartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telPartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        [ForeignKey(nameof(IdTypeDegustation))]
        [InverseProperty(nameof(TypeDegustation.Caves))]
        public virtual TypeDegustation? TypeDegustation { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.Cave))]
        public virtual Partenaire? Partenaire { get; set; }

    }
}
