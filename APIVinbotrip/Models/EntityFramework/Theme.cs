
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("THEME")]
    public partial class Theme
    {
        [Key]
        [Column("idTheme")]
        public int IdTheme { get; set; }

        [Column("libelleTheme")]
        [StringLength(50)]
        public string? LibelleTheme { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Sejour.IdthemeNavigation))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
