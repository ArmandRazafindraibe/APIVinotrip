using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("visite")]
    public partial class Visite
    {
        [Key]
        [Column("idvisite")]
        public int Idvisite { get; set; }

        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("descriptionvisite")]
        [StringLength(4096)]
        public string? Descriptionvisite { get; set; }

        [Column("photovisite")]
        [StringLength(512)]
        public string? Photovisite { get; set; }

        [Column("lienvisite")]
        [StringLength(512)]
        public string? Lienvisite { get; set; }

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Visites")]
        public virtual Cave IdpartenaireNavigation { get; set; } = null!;

        [ForeignKey("Idvisite")]
        [InverseProperty("Idvisites")]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();
    }
}
