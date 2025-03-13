using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("partenaire")]
    public partial class Partenaire
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

        [InverseProperty("IdpartenaireNavigation")]
        public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

        [InverseProperty("IdpartenaireNavigation")]
        public virtual Autresociete? Autresociete { get; set; }

        [InverseProperty("IdpartenaireNavigation")]
        public virtual Cave? Cave { get; set; }

        [InverseProperty("IdpartenaireNavigation")]
        public virtual Hotel? Hotel { get; set; }

        [InverseProperty("IdpartenaireNavigation")]
        public virtual Restaurant? Restaurant { get; set; }
    }
}
