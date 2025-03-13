using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{

    [Table("adresse")]
    public partial class Adresse
    {
        [Key]
        [Column("idadresse")]
        public int Idadresse { get; set; }

        [Column("idpartenaire")]
        public int? Idpartenaire { get; set; }

        [Column("idclient")]
        public int? Idclient { get; set; }

        [Column("nomadresse")]
        [StringLength(50)]
        public string? Nomadresse { get; set; }

        [Column("prenomadressedestinataire")]
        [StringLength(50)]
        public string? Prenomadressedestinataire { get; set; }

        [Column("nomadressedestinataire")]
        [StringLength(50)]
        public string? Nomadressedestinataire { get; set; }

        [Column("rueadresse")]
        [StringLength(100)]
        public string? Rueadresse { get; set; }

        [Column("villeadresse")]
        [StringLength(50)]
        public string? Villeadresse { get; set; }

        [Column("paysadresse")]
        [StringLength(50)]
        public string? Paysadresse { get; set; }

        [Column("cpadresse")]
        [StringLength(12)]
        public string? Cpadresse { get; set; }

        [Column("numadresse")]
        [StringLength(10)]
        public string? Numadresse { get; set; }

        [InverseProperty("IdadressefacturationNavigation")]
        public virtual ICollection<Commande> CommandeIdadressefacturationNavigations { get; set; } = new List<Commande>();

        [InverseProperty("IdadresselivraisonNavigation")]
        public virtual ICollection<Commande> CommandeIdadresselivraisonNavigations { get; set; } = new List<Commande>();

        [ForeignKey("Idclient")]
        [InverseProperty("Adresses")]
        public virtual Client? IdclientNavigation { get; set; }

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Adresses")]
        public virtual Partenaire? IdpartenaireNavigation { get; set; }

        [InverseProperty("IdadresseNavigation")]
        public virtual ICollection<Propose> Proposes { get; set; } = new List<Propose>();
    }
}