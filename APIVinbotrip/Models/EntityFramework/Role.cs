using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("roles")]
    public partial class Role
    {
        [Key]
        [Column("idrole")]
        public int Idrole { get; set; }

        [Column("libellerole")]
        [StringLength(50)]
        public string? Libellerole { get; set; }

        [InverseProperty("IdroleNavigation")]
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
