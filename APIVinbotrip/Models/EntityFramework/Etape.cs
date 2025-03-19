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

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Visite.Idetapes))]
        public virtual ICollection<Visite> Visites { get; set; } = new List<Visite>();

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Activite.Idetapes))]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Repas.Idetapes))]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();

        [InverseProperty(nameof(Inclus.SonEtape))]
        public virtual Etape? InclusCollection { get; set; }


    }


}
