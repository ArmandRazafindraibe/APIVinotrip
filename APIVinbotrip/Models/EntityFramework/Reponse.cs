
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("reponse")]
    public partial class Reponse
    {
        [Key]
        [Column("idreponse")]
        public int IdReponse { get; set; }

        [Column("idavis")]
        public int? IdAvis { get; set; }

        [Column("descriptionreponse")]
        [StringLength(2056)]
        public string? DescriptionReponse { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdAvis))]
        [InverseProperty(nameof(Avis.Reponses))]
        public virtual Avis? Avis { get; set; }
    }
}
