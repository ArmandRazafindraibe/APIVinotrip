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
        public int IdSejour { get; set; }

        // Additional properties for Etape

        [ForeignKey("IdSejour")]
        [InverseProperty(nameof(Sejour.Etapes))]
        public virtual Sejour? Sejour { get; set; }
    }

}
