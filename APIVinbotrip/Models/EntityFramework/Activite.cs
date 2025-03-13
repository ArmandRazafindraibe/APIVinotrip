using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("activite")]
    public partial class Activite
    {
        [Key]
        [Column("idactivite")]
        public int Idactivite { get; set; }

        [Column("libelleactivite")]
        [StringLength(100)]
        public string? Libelleactivite { get; set; }

        [Column("prixactivite")]
        [Precision(8, 2)]
        public decimal? Prixactivite { get; set; }

        [InverseProperty("IdactiviteNavigation")]
        public virtual ICollection<Propose> Proposes { get; set; } = new List<Propose>();

        [ForeignKey("Idactivite")]
        [InverseProperty("Idactivites")]
        public virtual ICollection<Descriptioncommande> Iddescriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [ForeignKey("Idactivite")]
        [InverseProperty("Idactivites")]
        public virtual ICollection<Descriptionpanier> Iddescriptionpaniers { get; set; } = new List<Descriptionpanier>();

        [ForeignKey("Idactivite")]
        [InverseProperty("Idactivites")]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();
    }
}
