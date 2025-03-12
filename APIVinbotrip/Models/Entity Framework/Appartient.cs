using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
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
        public virtual Visite? Visite { get; set; }

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.AppartientCollection))]
        public virtual Etape? Etape { get; set; }
    }
}
