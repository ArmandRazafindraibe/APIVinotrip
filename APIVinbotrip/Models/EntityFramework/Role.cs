using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("roles")]
    public partial class Role
    {
        [Key]
        [Column("idrole")]
        public int? IdRole { get; set; }

        [Column("libellerole")]
        [StringLength(50)]
        public string? LibelleRole { get; set; }

        [InverseProperty(nameof(Client.Role))]
        public virtual List<Client> Clients { get; set; } = new List<Client>();
    }
}
