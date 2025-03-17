using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("RESTAURANT")]
    public partial class Restaurant
    {
        [Key]
        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Column("idTypeCuisine")]
        public int? IdTypeCuisine { get; set; }

        [Column("nomPartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailPartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telPartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        [Column("nombreEtoilesRestaurant")]
        public int? NombreEtoilesRestaurant { get; set; }

        [Column("specialiteRestaurant")]
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
