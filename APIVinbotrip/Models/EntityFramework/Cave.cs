using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("cave")]
    public partial class Cave
    {
        [Key]
        [Column("idpartenaire")]
        public int IdPartenaire { get; set; }

        [Column("idtypedegustation")]
        public int? IdTypeDegustation { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? nompartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        [ForeignKey(nameof(IdTypeDegustation))]
        [InverseProperty(nameof(TypeDegustation.Caves))]
        public virtual TypeDegustation? TypeDegustation { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.Caves))]
        public virtual Partenaire? Partenaire { get; set; }

        [InverseProperty(nameof(Visite.LaCave))]
        public virtual List<Visite> Visites { get; set; }= new List<Visite>();

    }
}
