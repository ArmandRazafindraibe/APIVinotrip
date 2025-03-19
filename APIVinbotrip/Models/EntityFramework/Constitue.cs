using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    public partial class Constitue
    {
        [Key]
        [Column("idactivite")]
        public int IdActivite { get; set; }

        [Key]
        [Column("idsejour")]
        public int IdSejour { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Activite.Constitues))]
        public virtual Activite Activite { get; set; } = null!;

        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.Constitues))]
        public virtual Sejour Sejour { get; set; } = null!;
    }
}
