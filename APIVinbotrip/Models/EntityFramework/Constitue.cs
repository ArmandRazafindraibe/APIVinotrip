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
        [Column("idetape")]
        public int IdEtape { get; set; }

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Activite.Constitues))]
        public virtual Activite Activite { get; set; } = null!;

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.Constitues))]
        public virtual Etape Etape { get; set; } = null!;
    }
}
