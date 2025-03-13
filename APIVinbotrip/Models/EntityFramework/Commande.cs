using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("commande")]
 
    public partial class Commande
    {
        [Key]
        [Column("idcommande")]
        public int Idcommande { get; set; }

        [Column("idadressefacturation")]
        public int Idadressefacturation { get; set; }

        [Column("idcb")]
        public int? Idcb { get; set; }

        [Column("idclientbeneficiaire")]
        public int? Idclientbeneficiaire { get; set; }

        [Column("idpanier")]
        public int Idpanier { get; set; }

        [Column("idadresselivraison")]
        public int? Idadresselivraison { get; set; }

        [Column("idclientacheteur")]
        public int Idclientacheteur { get; set; }

        [Column("idcodepromo")]
        public int? Idcodepromo { get; set; }

        [Column("codereduction")]
        [StringLength(20)]
        public string? Codereduction { get; set; }

        [Column("validationclient")]
        public bool? Validationclient { get; set; }

        [Column("etatcommande")]
        [StringLength(50)]
        public string? Etatcommande { get; set; }

        [Column("typepaiementcommande")]
        [StringLength(50)]
        public string? Typepaiementcommande { get; set; }

        [Column("datecommande")]
        public DateOnly? Datecommande { get; set; }

        [InverseProperty("IdcommandeNavigation")]
        public virtual ICollection<Descriptioncommande> Descriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [ForeignKey("Idadressefacturation")]
        [InverseProperty("CommandeIdadressefacturationNavigations")]
        public virtual Adresse IdadressefacturationNavigation { get; set; } = null!;

        [ForeignKey("Idadresselivraison")]
        [InverseProperty("CommandeIdadresselivraisonNavigations")]
        public virtual Adresse? IdadresselivraisonNavigation { get; set; }

        [ForeignKey("Idcb")]
        [InverseProperty("Commandes")]
        public virtual CarteBancaire? IdcbNavigation { get; set; }

        [ForeignKey("Idclientacheteur")]
        [InverseProperty("CommandeIdclientacheteurNavigations")]
        public virtual Client IdclientacheteurNavigation { get; set; } = null!;

        [ForeignKey("Idclientbeneficiaire")]
        [InverseProperty("CommandeIdclientbeneficiaireNavigations")]
        public virtual Client? IdclientbeneficiaireNavigation { get; set; }

        [ForeignKey("Idcodepromo")]
        [InverseProperty("Commandes")]
        public virtual Codepromo? IdcodepromoNavigation { get; set; }

        [ForeignKey("Idpanier")]
        [InverseProperty("Commandes")]
        public virtual Panier IdpanierNavigation { get; set; } = null!;
    }
}
