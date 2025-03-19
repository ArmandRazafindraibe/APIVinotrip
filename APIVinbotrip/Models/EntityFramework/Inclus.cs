using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("inclus")]
    public partial class Inclus
    {
        [Key]
        [Column("idrepas")]
        public int IdRepas { get; set; }

        [Key]
        [Column("idetape")]
        public int IdEtape { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.Inclusions))]
        public virtual Repas Repas { get; set; } = null!;

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.InclusCollection))]
        public virtual Etape Etape { get; set; } = null!;
    }
}