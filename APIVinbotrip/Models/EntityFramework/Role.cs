using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("ROLES")]
    public partial class Role
    {
        [Key]
        [Column("idRole")]
        public int IdRole { get; set; }

        [Column("libelleRole")]
        [StringLength(50)]
        public string? LibelleRole { get; set; }

        [InverseProperty(nameof(Client.Role))]
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
