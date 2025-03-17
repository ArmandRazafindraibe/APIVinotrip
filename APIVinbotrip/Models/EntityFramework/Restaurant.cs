using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("restaurant")]
    public partial class Restaurant
    {
        [Key]
        [Column("idpartenaire")]
        public int IdPartenaire { get; set; }

        [Column("idtypecuisine")]
        public int? IdTypeCuisine { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        [Column("nombreetoilesrestaurant")]
        public int? NombreEtoilesRestaurant { get; set; }

        [Column("specialiterestaurant")]
        [StringLength(50)]
        public string? SpecialiteRestaurant { get; set; }
        
        [ForeignKey(nameof(IdTypeCuisine))]
        [InverseProperty(nameof(TypeCuisine.Restaurants))]
        public virtual TypeCuisine? TypeCuisine { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.Restaurants))]
        public virtual Partenaire? Partenaire { get; set; }

        [InverseProperty(nameof(Repas.RestaurantRepas))]
        public virtual ICollection<Repas> RepasCollection { get; set; } = new List<Repas>();


    }
}
