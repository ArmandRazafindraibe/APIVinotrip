using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("theme")]
    public partial class Theme
    {
        [Key]
        [Column("idtheme")]
        public int Idtheme { get; set; }

        [Column("libelletheme")]
        [StringLength(50)]
        public string? Libelletheme { get; set; }

        [InverseProperty("IdthemeNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
