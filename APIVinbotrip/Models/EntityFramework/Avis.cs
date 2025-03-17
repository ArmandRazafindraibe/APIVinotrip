using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("avis")]
    public partial class Avis
    {
        [Key]
        [Column("idavis")]
        public int IdAvis { get; set; }

        [Column("idsejour")]
        public int? IdSejour { get; set; }

        [Column("idclient")]
        public int? IdClient { get; set; }

        [Column("dateavis")]
        public DateTime? DateAvis { get; set; }

        [Column("titreavis")]
        [StringLength(100)]
        public string? TitreAvis { get; set; }

        [Column("descriptionavis")]
        [StringLength(2048)]
        public string? DescriptionAvis { get; set; }

        [Column("noteavis")]
        public int? NoteAvis { get; set; }

        [Column("photoavis")]
        [StringLength(512)]
        public string? PhotoAvis { get; set; }

        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.AvisNavigation))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.LesAvis))]
        public virtual Client? Client { get; set; }

        
        [InverseProperty(nameof(Reponse.Avis))]
        public virtual ICollection<Reponse> Reponses { get; set; } = new List<Reponse>();
    }
}
