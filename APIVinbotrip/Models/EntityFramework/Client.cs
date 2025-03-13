using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("client")]
    public partial class Client
    {
        [Key]
        [Column("idclient")]
        public int Idclient { get; set; }

        [Column("idrole")]
        public int Idrole { get; set; }

        [Column("civiliteclient")]
        [StringLength(10)]
        public string? Civiliteclient { get; set; }

        [Column("prenomclient")]
        [StringLength(50)]
        public string? Prenomclient { get; set; }

        [Column("nomclient")]
        [StringLength(50)]
        public string? Nomclient { get; set; }

        [Column("emailclient")]
        [StringLength(150)]
        public string? Emailclient { get; set; }

        [Column("datenaissanceclient")]
        public DateOnly? Datenaissanceclient { get; set; }

        [Column("motdepasseclient")]
        [StringLength(512)]
        public string? Motdepasseclient { get; set; }

        [Column("offrespromotionnellesclient")]
        public bool? Offrespromotionnellesclient { get; set; }

        [Column("datederniereactiviteclient")]
        public DateOnly? Datederniereactiviteclient { get; set; }

        [Column("a2f")]
        public bool A2f { get; set; }

        [Column("telephoneclient")]
        [StringLength(10)]
        public string? Telephoneclient { get; set; }

        [Column("tokenresetmdp")]
        [StringLength(60)]
        public string? Tokenresetmdp { get; set; }

        [Column("datecreationtoken")]
        public DateOnly? Datecreationtoken { get; set; }

        [InverseProperty("IdclientNavigation")]
        public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

        [InverseProperty("IdclientNavigation")]
        public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

        [InverseProperty("IdclientNavigation")]
        public virtual ICollection<CarteBancaire> CarteBancaires { get; set; } = new List<CarteBancaire>();

        [InverseProperty("IdclientacheteurNavigation")]
        public virtual ICollection<Commande> CommandeIdclientacheteurNavigations { get; set; } = new List<Commande>();

        [InverseProperty("IdclientbeneficiaireNavigation")]
        public virtual ICollection<Commande> CommandeIdclientbeneficiaireNavigations { get; set; } = new List<Commande>();

        [ForeignKey("Idrole")]
        [InverseProperty("Clients")]
        public virtual Role IdroleNavigation { get; set; } = null!;

        [ForeignKey("Idclient")]
        [InverseProperty("Idclients")]
        public virtual ICollection<Sejour> Idsejours { get; set; } = new List<Sejour>();
    }
}
