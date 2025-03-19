using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("Appartient")]
    public partial class Appartient
    {
        [Key, Column("idVisite")]
        public int IdVisite { get; set; }

        [Key, Column("idEtape")]
        public int IdEtape { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdVisite))]
        [InverseProperty(nameof(Visite.AppartientCollection))]
        public virtual ICollection<Visite>? LesVisite { get; set; }

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.AppartientCollection))]
        public virtual Etape? SonEtape { get; set; }
    }
}
