using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("localite")]
    public partial class Localite
    {
        [Key]
        [Column("idlocalite")]
        public int Idlocalite { get; set; }

        [Column("idcategorievignoble")]
        public int Idcategorievignoble { get; set; }

        [Column("libellelocalite")]
        [StringLength(50)]
        public string? Libellelocalite { get; set; }

        [ForeignKey("Idcategorievignoble")]
        [InverseProperty("Localites")]
        public virtual Categorievignoble IdcategorievignobleNavigation { get; set; } = null!;

        [InverseProperty("IdlocaliteNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
