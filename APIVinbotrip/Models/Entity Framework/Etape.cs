using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.Entity_Framework;

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
        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.Etapes))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.LesEtapes))]
        public virtual Partenaire? Partenaire { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Inclus.Etape))]
        public virtual ICollection<Inclus> InclusCollection { get; set; } = new List<Inclus>();


    }


}
