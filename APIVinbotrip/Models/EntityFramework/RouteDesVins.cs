
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("route_des_vins")]
    public partial class RouteDesVins
    {
        [Key]
        [Column("idroute")]
        public int IdRoute { get; set; }

        [Column("titreroute")]
        [StringLength(50)]
        public string? LibRoute { get; set; }

        [Column("descriptionroute")]
        [StringLength(2048)]
        public string? DescriptionRoute { get; set; }

        [Column("photoroute")]
        [StringLength(512)]
        public string? PhotoRoute { get; set; }

        [InverseProperty(nameof(SeLocalise.Route))]
        public virtual List<SeLocalise> SesLocalites { get; set; } = new List<SeLocalise>();

        public override bool Equals(object? obj)
        {
            return obj is RouteDesVins vins &&
                   IdRoute == vins.IdRoute &&
                   LibRoute == vins.LibRoute &&
                   DescriptionRoute == vins.DescriptionRoute &&
                   PhotoRoute == vins.PhotoRoute;
        }
    }
}
