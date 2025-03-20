using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categoriesejour")]
    public partial class CategorieSejour
    {
        [Key]
        [Column("idcategoriesejour")]
        public int IdCategorieSejour { get; set; }

        [Column("libellecategoriessejour")]
        [StringLength(50)]
        public string? LibelleCategoriesSejour { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Sejour.IdcategoriesejourNavigation))]
        public virtual List<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
