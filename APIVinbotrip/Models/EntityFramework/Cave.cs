using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("cave")]
    
    public partial class Cave
    {
        [Key]
        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("idtypedegustation")]
        public int Idtypedegustation { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? Nompartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? Mailpartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? Telpartenaire { get; set; }

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Cave")]
        public virtual Partenaire IdpartenaireNavigation { get; set; } = null!;

        [ForeignKey("Idtypedegustation")]
        [InverseProperty("Caves")]
        public virtual Typedegustation IdtypedegustationNavigation { get; set; } = null!;

        [InverseProperty("IdpartenaireNavigation")]
        public virtual ICollection<Visite> Visites { get; set; } = new List<Visite>();
    }
}
