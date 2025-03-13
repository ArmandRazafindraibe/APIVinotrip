using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("panier")]
    public partial class Panier
    {
        [Key]
        [Column("idpanier")]
        public int Idpanier { get; set; }

        [Column("idcodepromo")]
        public int? Idcodepromo { get; set; }

        [Column("dateheurepanier")]
        public DateOnly? Dateheurepanier { get; set; }

        [InverseProperty("IdpanierNavigation")]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty("IdpanierNavigation")]
        public virtual ICollection<Descriptionpanier> Descriptionpaniers { get; set; } = new List<Descriptionpanier>();

        [ForeignKey("Idcodepromo")]
        [InverseProperty("Paniers")]
        public virtual Codepromo? IdcodepromoNavigation { get; set; }
    }
}
