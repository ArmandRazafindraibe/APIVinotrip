using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("route_des_vins")]
    public partial class RouteDesVin
    {
        [Key]
        [Column("idroute")]
        public int Idroute { get; set; }

        [Column("titreroute")]
        [StringLength(120)]
        public string? Titreroute { get; set; }

        [Column("descriptionroute")]
        [StringLength(2048)]
        public string? Descriptionroute { get; set; }

        [Column("photoroute")]
        [StringLength(512)]
        public string? Photoroute { get; set; }

        [ForeignKey("Idroute")]
        [InverseProperty("Idroutes")]
        public virtual ICollection<Categorievignoble> Idcategorievignobles { get; set; } = new List<Categorievignoble>();
    }

}
