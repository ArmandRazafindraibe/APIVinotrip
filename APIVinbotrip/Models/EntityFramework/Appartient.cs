using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("appartient")]
    public partial class Appartient
    {
        [Key, Column("idvisite")]
        public int IdVisite { get; set; }

        [Key, Column("idetape")]
        public int IdEtape { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdVisite))]
        [InverseProperty(nameof(Visite.AppartientCollection))]
        public virtual Visite? LaVisite { get; set; }

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.AppartientCollection))]
        public virtual Etape? SonEtape { get; set; }
    }
}
