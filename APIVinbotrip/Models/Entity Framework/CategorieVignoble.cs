using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("CATEGORIEVIGNOBLE")]
    public partial class CategorieVignoble
    {
        [Key]
        [Column("idCategorieVignoble")]
        public int IdCategorieVignoble { get; set; }

        [Column("libelleCategorieVignoble")]
        [StringLength(50)]
        public string? LibelleCategorieVignoble { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Localite.CategorieVignoble))]
        public virtual ICollection<Localite> Localites { get; set; } = new List<Localite>();

        [InverseProperty(nameof(SeLocalise.CategorieVignoble))]
        public virtual ICollection<SaLocalite> SaLocalites { get; set; } = new List<SaLocalite>();

        [InverseProperty(nameof(Sejour.CategorieVignoble))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
