using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.EntityFramework;

namespace APIVinbotrip.Models.EntityFramework
{
    [Table("ETAPE")]
    public partial class Etape
    {
        [Key]
        [Column("idEtape")]
        public int IdEtape { get; set; }

        [Column("idSejour")]
        public int? IdSejour { get; set; }

        [Column("idHebergement")]
        public int? IdHebergement { get; set; }

        [Column("titreEtape")]
        [StringLength(100)]
        public string? TitreEtape { get; set; }

        [Column("descriptionEtape")]
        [StringLength(4096)]
        public string? DescriptionEtape { get; set; }

        [Column("photoEtape")]
        [StringLength(512)]
        public string? PhotoEtape { get; set; }

        [Column("URLEtape")]
        [StringLength(150)]
        public string? URLEtape { get; set; }

        [Column("videoEtape")]
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




    }


}
