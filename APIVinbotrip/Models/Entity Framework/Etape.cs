using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("ETAPE")]
    public partial class Etape
    {
        [Key]
        [Column("idEtape")]
        public int IdEtape { get; set; }

        [Column("idSejour")]
        public int? IdSejour { get; set; }

        [Column("idPartenaire")]
        public int? IdPartenaire { get; set; }

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
        [ForeignKey("IdSejour")]
        [InverseProperty(nameof(Sejour.Etapes))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey("IdPartenaire")]
        [InverseProperty(nameof(Partenaire.Etapes))]
        public virtual Partenaire? Partenaire { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Appartient.Etape))]
        public virtual ICollection<Appartient> AppartientCollection { get; set; } = new List<Appartient>();

        [InverseProperty(nameof(Appartient2.Etape))]
        public virtual ICollection<Appartient2> Appartient2Collection { get; set; } = new List<Appartient2>();
    }


}
