using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("carte_bancaire")]

    public partial class CarteBancaire
    {
        [Key]
        [Column("idcb")]
        public int Idcb { get; set; }

        [Column("idclient")]
        public int Idclient { get; set; }

        [Column("titulairecb")]
        [StringLength(1024)]
        public string? Titulairecb { get; set; }

        [Column("numerocbclient")]
        [StringLength(74)]
        public string? Numerocbclient { get; set; }

        [Column("dateexpirationcbclient")]
        [StringLength(58)]
        public string? Dateexpirationcbclient { get; set; }

        [Column("actif")]
        public bool? Actif { get; set; }

        [InverseProperty("IdcbNavigation")]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty("IdcbNavigation")]
        public virtual ICollection<Descriptioncommande> Descriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [ForeignKey("Idclient")]
        [InverseProperty("CarteBancaires")]
        public virtual Client IdclientNavigation { get; set; } = null!;
    }
}
