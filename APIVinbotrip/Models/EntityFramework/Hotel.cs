using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("hotel")]
    public partial class Hotel
    {
        [Key]
        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? Nompartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? Mailpartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? Telpartenaire { get; set; }

        [Column("nombrechambreshotel")]
        public int? Nombrechambreshotel { get; set; }

        [Column("categoriehotel")]
        public int? Categoriehotel { get; set; }

        [InverseProperty("IdpartenaireNavigation")]
        public virtual ICollection<Hebergement> Hebergements { get; set; } = new List<Hebergement>();

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Hotel")]
        public virtual Partenaire IdpartenaireNavigation { get; set; } = null!;
    }

}
