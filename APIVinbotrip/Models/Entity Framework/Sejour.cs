using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("SEJOUR")]
    public class Sejour
    {
        [Key]
        [Column("idSejour")]
        public int IdSejour { get; set; }

        [Column("titreSejour")]
        [StringLength(100)]
        public string? TitreSejour { get; set; }

        [Column("photoSejour")]
        [StringLength(512)]
        public string? PhotoSejour { get; set; }

        [Column("descriptionSejour")]
        [StringLength(4096)]
        public string? DescriptionSejour { get; set; }

        [Column("prixSejour", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixSejour { get; set; }

        [Column("publie")]
        public bool? Publie { get; set; }

        [Column("nouveauPrixSejour", TypeName = "NUMERIC(8,2)")]
        public decimal? NouveauPrixSejour { get; set; }

        [Column("idDuree")]
        public int IdDuree { get; set; }

        [Column("idCategorieVignoble")]
        public int IdCategorieVignoble { get; set; }

        [Column("idLocalite")]
        public int IdLocalite { get; set; }

        [Column("idTheme")]
        public int IdTheme { get; set; }

        [Column("idParticipant")]
        public int IdParticipant { get; set; }

        [InverseProperty(nameof(Duree.Sejours))]
        public virtual Duree? DureeSejour { get; set; }

        [InverseProperty(nameof(CategorieVignoble.Sejours))]
        public virtual CategorieVignoble? CategorieVignobleSejour { get; set; }

        [InverseProperty(nameof(Localite.Sejours))]
        public virtual Localite? LocaliteSejour { get; set; }

        [InverseProperty(nameof(Theme.Sejours))]
        public virtual Theme? ThemeSejour { get; set; }

        [InverseProperty(nameof(Participant.Sejours))]
        public virtual Participant? ParticipantSejour { get; set; }
    }
}