using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categoriesejour")]
    public partial class Categoriesejour
    {
        [Key]
        [Column("idcategoriesejour")]
        public int Idcategoriesejour { get; set; }

        [Column("libellecategoriesejour")]
        [StringLength(50)]
        public string? Libellecategoriesejour { get; set; }

        [InverseProperty("IdcategoriesejourNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
