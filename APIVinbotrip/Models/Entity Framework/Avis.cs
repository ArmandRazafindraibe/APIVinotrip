using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("AVIS")]
    public partial class Avis
    {
        [Key]
        [Column("idAvis")]
        public int IdAvis { get; set; }

        [Column("idSejour")]
        public int IdSejour { get; set; }

        // Additional properties for Avis

        [ForeignKey("IdSejour")]
        [InverseProperty(nameof(Sejour.Avis))]
        public virtual Sejour? Sejour { get; set; }
    }
}
