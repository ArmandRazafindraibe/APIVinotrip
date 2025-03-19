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
        [InverseProperty(nameof(Repas.Inclusions))]
        public virtual Repas? LesRepas { get; set; }

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.InclusCollection))]
        public virtual Etape? SonEtape { get; set; }
    }
}
