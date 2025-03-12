using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.Entity_Framework;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("LOCALITE")]
    public partial class Localite
    {
            [Key]
            [Column("idLocalite")]
            public int IdLocalite { get; set; }

            [Column("libelleLocalite")]
            [StringLength(50)]
            public string? LibelleLocalite { get; set; }

            [InverseProperty(nameof(Sejour.Localite))]
            public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();

            [ForeignKey("idCategorieVignoble")]    
            [InverseProperty(nameof(Sejour.Localite))]
            public virtual ICollection<CategorieVignoble> CategorieVignoble { get; set; } = new List<CategorieVignoble>();
    }
}
