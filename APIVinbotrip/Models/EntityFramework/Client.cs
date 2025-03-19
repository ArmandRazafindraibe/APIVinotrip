using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("client")]
    public partial class Client
    {
        [Key]
        [Column("idclient")]
        public int IdClient { get; set; }

        [Column("civiliteclient")]
        [MaxLength(5)]
        public string? CiviliteClient { get; set; }

        [Column("nomclient")]
        [StringLength(50)]
        public string? NomClient { get; set; }

        [Column("prenomclient")]
        [StringLength(50)]
        public string? PrenomClient { get; set; }

        [Column("emailclient")]
        [StringLength(100)]
        public string? EmailClient { get; set; }

        [Column("mdpclient")]
        [StringLength(500)]
        public string? MdpClient { get; set; }

        [Column("datenaissanceclient")]
        public DateTime? DateNaissanceClient { get; set; }

        [Column("datecreationcompteclient")]
        public DateTime? DateCreationCompteClient { get; set; }

        [Column("telclient")]
        [StringLength(12)]
        public string? TelClient { get; set; }

        [Column("datederniereactiviteclient")]
        public DateTime? DateDerniereActiviteClient { get; set; }
        [Column("a2f")]
        public bool A2f { get; set; }

        [Column("offrespromotionnellesclient")]
        public bool offresPromotionnellesClient { get; set; }

        [Column("idrole")]
        public int? IdRole { get; set; }

        [Column("bloquingclient")]
        public bool? BloquingClient { get; set; }

        [Column("tokenresetmdp")]
        [StringLength(50)]
        public string? TokenResetMDP { get; set; }

        [Column("datecreationtoken")]
        public DateTime? DateCreationToken { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(Role.Clients))]
        public virtual Role? Role { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Adresse.Client))]
        public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Commande.ClientAcheteur))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Commande.ClientBeneficiaire))]
        public virtual ICollection<Commande> CommandesOfferts { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Avis.Client))]
        public virtual ICollection<Avis> LesAvis { get; set; } = new List<Avis>();

        [InverseProperty(nameof(CarteBancaire.Client))]
        public virtual ICollection<CarteBancaire> CartesBancaires { get; set; } = new List<CarteBancaire>();

        [ForeignKey(nameof(IdClient))]

        [InverseProperty(nameof(Sejour.Idclients))]
        public virtual ICollection<Sejour> Idsejours { get; set; } = new List<Sejour>();

        [InverseProperty(nameof(Favoris.Sejours))]
        public virtual ICollection<Favoris> ListeFavoris { get; set; } = new List<Favoris>();


    }
}
