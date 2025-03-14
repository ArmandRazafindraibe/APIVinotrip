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
        [InverseProperty(nameof(Localite.CategoriesVignoble))]
        public virtual ICollection<Localite> Localites { get; set; } = new List<Localite>();

        [InverseProperty(nameof(Sejour.Idcategorievignoble))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
        [ForeignKey(nameof(IdCategorieVignoble))]
        [InverseProperty(nameof(RouteDesVins.Idcategorievignobles))]
        public virtual ICollection<RouteDesVins> Idroutes { get; set; } = new List<RouteDesVins>();
    }
}
