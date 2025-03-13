using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("restaurant")]
    
    public partial class Restaurant
    {
        [Key]
        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("idtypecuisine")]
        public int Idtypecuisine { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? Nompartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? Mailpartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? Telpartenaire { get; set; }

        [Column("nombreetoilesrestaurant")]
        public int? Nombreetoilesrestaurant { get; set; }

        [Column("specialiterestaurant")]
        [StringLength(50)]
        public string? Specialiterestaurant { get; set; }

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Restaurant")]
        public virtual Partenaire IdpartenaireNavigation { get; set; } = null!;

        [ForeignKey("Idtypecuisine")]
        [InverseProperty("Restaurants")]
        public virtual Typecuisine IdtypecuisineNavigation { get; set; } = null!;

        [InverseProperty("IdpartenaireNavigation")]
        public virtual ICollection<Repas> Repas { get; set; } = new List<Repas>();

    }
}
