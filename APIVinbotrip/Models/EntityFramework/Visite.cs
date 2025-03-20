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
        public virtual Cave? LaCave { get; set; }

        [InverseProperty(nameof(Appartient.LaVisite))]
        public virtual List<Appartient>? AppartientCollection { get; set; } = new List<Appartient>();

    }
}
