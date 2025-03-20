
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("theme")]
    public partial class Theme
    {
        [Key]
        [Column("idtheme")]
        public int IdTheme { get; set; }

        [Column("libelletheme")]
        [StringLength(50)]
        public string? LibelleTheme { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Sejour.IdthemeNavigation))]
        public virtual List<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
