using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("etape")]
    public partial class Etape
    {
        [Key]
        [Column("idetape")]
        public int IdEtape { get; set; }

        [Column("idsejour")]
        public int? IdSejour { get; set; }

        [Column("idhebergement")]
        public int? IdHebergement { get; set; }

        [Column("titreetape")]
        [StringLength(100)]
        public string? TitreEtape { get; set; }

        [Column("descriptionetape")]
        [StringLength(4096)]
        public string? DescriptionEtape { get; set; }

        [Column("photoetape")]
        [StringLength(512)]
        public string? PhotoEtape { get; set; }

        [Column("urletape")]
        [StringLength(150)]
        public string? URLEtape { get; set; }

        [Column("videoetape")]
        [StringLength(512)]
        public string? VideoEtape { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.Etapes))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey(nameof(IdHebergement))]
        [InverseProperty(nameof(Hebergement.Etapes))]
        public virtual Hebergement? Hebergement { get; set; }

        [InverseProperty(nameof(Inclus.Etape))]
        public virtual List<Inclus>? InclusCollection { get; set; } = new List<Inclus>();

        [InverseProperty(nameof(Constitue.SonEtape))]
        public virtual List<Constitue> Constitues { get; set; } = new List<Constitue>();

        [InverseProperty(nameof(Appartient.SonEtape))]
        public virtual List<Appartient> AppartientCollection { get; set; } = new List<Appartient>();
    }


}
