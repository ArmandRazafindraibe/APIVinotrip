using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("duree")]
    public partial class Duree
    {
        [Key]
        [Column("idduree")]
        public int Idduree { get; set; }

        [Column("libelleduree")]
        [StringLength(50)]
        public string? Libelleduree { get; set; }

        [InverseProperty("IddureeNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
