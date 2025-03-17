using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("typedegustation")]
    public partial class TypeDegustation
    {
        [Key]
        [Column("idtypedegustation")]
        public int IdTypeDegustation { get; set; }

        [Column("libelletypedegustation")]
        [StringLength(50)]
        public string? LibelleTypeDegustation { get; set; }

        [InverseProperty(nameof(Cave.TypeDegustation))]
        public virtual ICollection<Cave> Caves { get; set; } = new List<Cave>();

    }
}
