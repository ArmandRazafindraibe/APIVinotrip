using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("typecuisine")]
    public partial class Typecuisine
    {
        [Key]
        [Column("idtypecuisine")]
        public int Idtypecuisine { get; set; }

        [Column("libelletypecuisine")]
        [StringLength(50)]
        public string? Libelletypecuisine { get; set; }

        [InverseProperty("IdtypecuisineNavigation")]
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }

}
