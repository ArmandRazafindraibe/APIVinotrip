using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("typecuisine")]
    public partial class TypeCuisine
    {
        [Key]
        [Column("idtypecuisine")]
        public int IdTypeCuisine { get; set; }

        [Column("libelletypecuisine")]
        [StringLength(50)]
        public string? LibelleTypeCuisine { get; set; }

        [InverseProperty(nameof(Restaurant.TypeCuisine))]
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
