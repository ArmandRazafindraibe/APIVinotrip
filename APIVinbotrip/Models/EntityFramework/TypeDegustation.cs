using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("typedegustation")]
    public partial class Typedegustation
    {
        [Key]
        [Column("idtypedegustation")]
        public int Idtypedegustation { get; set; }

        [Column("libelletypedegustation")]
        [StringLength(50)]
        public string? Libelletypedegustation { get; set; }

        [InverseProperty("IdtypedegustationNavigation")]
        public virtual ICollection<Cave> Caves { get; set; } = new List<Cave>();
    }
}
