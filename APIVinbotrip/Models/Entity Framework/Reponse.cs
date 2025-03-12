using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("REPONSE")]
    public partial class Reponse
    {
        [Key]
        [Column("idReponse")]
        public int IdReponse { get; set; }

        [Column("idAvis")]
        public int? IdAvis { get; set; }

        [Column("descriptionReponse")]
        [StringLength(2056)]
        public string? DescriptionReponse { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdAvis))]
        [InverseProperty(nameof(Avis.Reponses))]
        public virtual Avis? Avis { get; set; }
    }
}
