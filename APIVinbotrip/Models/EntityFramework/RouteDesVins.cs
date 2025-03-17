
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

        [Column("libroute")]
        [StringLength(50)]
        public string? LibRoute { get; set; }

        [Column("descriptionroute")]
        [StringLength(2048)]
        public string? DescriptionRoute { get; set; }

        [Column("photoroute")]
        [StringLength(512)]
        public string? PhotoRoute { get; set; }

        // Collection navigation properties
        [ForeignKey(nameof(IdRoute))]
        [InverseProperty(nameof(CategorieVignoble.Idroutes))]
        public virtual ICollection<CategorieVignoble> Idcategorievignobles { get; set; } = new List<CategorieVignoble>();
       
    }
}
