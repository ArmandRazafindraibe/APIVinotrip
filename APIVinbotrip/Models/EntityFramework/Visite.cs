using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("visite")]
    public partial class Visite
    {
        [Key]
        [Column("idvisite")]
        public int IdVisite { get; set; }

        [Column("idpartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("descriptionvisite")]
        [StringLength(4096)]
        public string? DescriptionVisite { get; set; }

        [Column("photovisite")]
        [StringLength(512)]
        public string? PhotoVisite { get; set; }

        [Column("lienvisite")]
        [StringLength(512)]
        public string? LienVisite { get; set; }
        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Cave.Visites))]
        public virtual Cave? Cave { get; set; }

        [ForeignKey(nameof(IdVisite))]
        [InverseProperty(nameof(Etape.Visites))]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();

        [InverseProperty(nameof(Appartient.LaVisite))]
        public virtual ICollection<Visite>? AppartientCollection { get; set; }

    }
}
