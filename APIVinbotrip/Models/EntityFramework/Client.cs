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

        [Column("idrole")]
        public int? IdRole { get; set; }

        [Column("civiliteclient")]
        [MaxLength(5)]
        public string? CiviliteClient { get; set; }

        [Column("prenomclient")]
        [StringLength(50)]
        public string? PrenomClient { get; set; }

        [Column("nomclient")]
        [StringLength(50)]
        public string? NomClient { get; set; }

        [Column("emailclient")]
        [StringLength(100)]
        public string? EmailClient { get; set; }

        [Column("datenaissanceclient", TypeName = "date")]
        public DateTime? DateNaissanceClient { get; set; }

        [Column("motdepasseclient")]
        [StringLength(500)]
        public string? MdpClient { get; set; }

        [Column("offrespromotionnellesclient")]
        public bool offresPromotionnellesClient { get; set; }

        [Column("datederniereactiviteclient", TypeName = "date")]
        public DateTime? DateDerniereActiviteClient { get; set; }

        [Column("a2f")]
        public bool A2f { get; set; }

        [Column("telephoneclient")]
        [StringLength(12)]
        public string? TelClient { get; set; }

        [Column("tokenresetmdp")]
        [StringLength(50)]
        public string? TokenResetMDP { get; set; }

        [Column("datecreationtoken", TypeName = "date")]
        public DateTime? DateCreationToken { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(Role.Clients))]
        public virtual Role? Role { get; set; }


        // Collection navigation properties

        [InverseProperty(nameof(Adresse.Client))]
        public virtual List<Adresse> Adresses { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Commande.ClientAcheteur))]
        public virtual List<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Commande.ClientBeneficiaire))]
        public virtual List<Commande> CommandesOfferts { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Avis.Client))]
        public virtual List<Avis> LesAvis { get; set; } = new List<Avis>();

        [InverseProperty(nameof(CarteBancaire.Client))]
        public virtual List<CarteBancaire> CartesBancaires { get; set; } = new List<CarteBancaire>();

        [InverseProperty(nameof(Favoris.LeClient))]
        public virtual List<Favoris> ListeFavoris { get; set; } = new List<Favoris>();

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   IdClient == client.IdClient &&
                   IdRole == client.IdRole &&
                   CiviliteClient == client.CiviliteClient &&
                   PrenomClient == client.PrenomClient &&
                   NomClient == client.NomClient &&
                   EmailClient == client.EmailClient &&
                   DateNaissanceClient == client.DateNaissanceClient &&
                   MdpClient == client.MdpClient &&
                   offresPromotionnellesClient == client.offresPromotionnellesClient &&
                   DateDerniereActiviteClient == client.DateDerniereActiviteClient &&
                   A2f == client.A2f &&
                   TelClient == client.TelClient &&
                   TokenResetMDP == client.TokenResetMDP &&
                   DateCreationToken == client.DateCreationToken;
        }
    }
}
