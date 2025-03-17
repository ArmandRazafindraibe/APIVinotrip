using APIVinbotrip.Models.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("CATEGORIESEJOUR")]
    public partial class CategorieSejour
    {
        [Key]
        [Column("idCategorieSejour")]
        public int IdCategorieSejour { get; set; }

        [Column("libelleCategoriesSejour")]
        [StringLength(50)]
        public string? LibelleCategoriesSejour { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Sejour.Idcategoriesejour))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
