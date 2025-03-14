using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.Entity_Framework;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("VISITE")]
    public partial class Visite
    {
        [Key]
        [Column("idVisite")]
        public int IdVisite { get; set; }

        [Column("idPartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("descriptionVisite")]
        [StringLength(4096)]
        public string? DescriptionVisite { get; set; }

        [Column("photoVisite")]
        [StringLength(512)]
        public string? PhotoVisite { get; set; }

        [Column("lienVisite")]
        [StringLength(512)]
        public string? LienVisite { get; set; }
        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Cave.Visites))]
        public virtual Cave? Cave { get; set; }

        [ForeignKey(nameof(IdVisite))]
        [InverseProperty(nameof(Etape.Visites))]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();


    }
}
