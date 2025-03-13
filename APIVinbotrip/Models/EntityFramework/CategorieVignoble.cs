using APIVinotrip.Models.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categorievignoble")]
    public partial class Categorievignoble
    {
        [Key]
        [Column("idcategorievignoble")]
        public int Idcategorievignoble { get; set; }

        [Column("libellecategorievignoble")]
        [StringLength(50)]
        public string? Libellecategorievignoble { get; set; }

        [InverseProperty("IdcategorievignobleNavigation")]
        public virtual ICollection<Localite> Localites { get; set; } = new List<Localite>();

        [InverseProperty("IdcategorievignobleNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();

        [ForeignKey("Idcategorievignoble")]
        [InverseProperty("Idcategorievignobles")]
        public virtual ICollection<RouteDesVin> Idroutes { get; set; } = new List<RouteDesVin>();
    }
}
