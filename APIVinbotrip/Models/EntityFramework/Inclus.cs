using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("Inclus")]
    public partial class Inclus
    {
        [Key, Column("idRepas")]
        public int IdRepas { get; set; }

        [Key, Column("idEtape")]
        public int IdEtape { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.InclusCollection))]
        public virtual Repas? Repas { get; set; }

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.InclusCollection))]
        public virtual Etape? Etape { get; set; }
    }
}
