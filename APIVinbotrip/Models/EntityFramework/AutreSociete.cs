using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("autresociete")]
    [Index("Idpartenaire", Name = "autresociete_pk", IsUnique = true)]
    public partial class Autresociete
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

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Autresociete")]
        public virtual Partenaire IdpartenaireNavigation { get; set; } = null!;

        [InverseProperty("IdpartenaireNavigation")]
        public virtual ICollection<Propose> Proposes { get; set; } = new List<Propose>();
    }
}

