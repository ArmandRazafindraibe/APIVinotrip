using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
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
        [InverseProperty(nameof(Sejour.Theme))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
