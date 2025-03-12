using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("TYPEDEGUSTATION")]
    public partial class TypeDegustation
    {
        [Key]
        [Column("idTypeDegustation")]
        public int IdTypeDegustation { get; set; }

        [Column("libelleTypeDegustation")]
        [StringLength(50)]
        public string? LibelleTypeDegustation { get; set; }

        [InverseProperty(nameof(Cave.TypeDegustation))]
        public virtual ICollection<Cave> Caves { get; set; } = new List<Cave>();

    }
}
