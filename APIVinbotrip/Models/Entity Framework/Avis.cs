using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.Entity_Framework;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("AVIS")]
    public partial class Avis
    {
        [Key]
        [Column("idAvis")]
        public int IdAvis { get; set; }

        [Column("idSejour")]
        public int? IdSejour { get; set; }

        [Column("idClient")]
        public int? IdClient { get; set; }

        [Column("dateAvis")]
        public DateTime? DateAvis { get; set; }

        [Column("titreAvis")]
        [StringLength(100)]
        public string? TitreAvis { get; set; }

        [Column("descriptionAvis")]
        [StringLength(2048)]
        public string? DescriptionAvis { get; set; }

        [Column("noteAvis")]
        public int? NoteAvis { get; set; }

        [Column("photoAvis")]
        [StringLength(512)]
        public string? PhotoAvis { get; set; }

        [ForeignKey("IdSejour")]
        [InverseProperty(nameof(Sejour.LesAvisSejour))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty(nameof(Client.Avis))]
        public virtual Client? Client { get; set; }

        
        [InverseProperty(nameof(Reponse.Avis))]
        public virtual ICollection<Reponse> Reponses { get; set; } = new List<Reponse>();
    }
}
