using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("CLIENT")]
    public partial class Client
    {
        [Key]
        [Column("idClient")]
        public int IdClient { get; set; }

        [Column("nomClient")]
        [StringLength(50)]
        public string? NomClient { get; set; }

        [Column("prenomClient")]
        [StringLength(50)]
        public string? PrenomClient { get; set; }

        [Column("emailClient")]
        [StringLength(100)]
        public string? EmailClient { get; set; }

        [Column("mdpClient")]
        [StringLength(50)]
        public string? MdpClient { get; set; }

        [Column("dateNaissanceClient")]
        public DateTime? DateNaissanceClient { get; set; }

        [Column("dateCreationCompteClient")]
        public DateTime? DateCreationCompteClient { get; set; }

        [Column("telClient")]
        [StringLength(12)]
        public string? TelClient { get; set; }

        [Column("dateDerniereActiviteClient")]
        public DateTime? DateDerniereActiviteClient { get; set; }

        [Column("idRole")]
        public int? IdRole { get; set; }

        [Column("bloquingClient")]
        public bool? BloquingClient { get; set; }

        [Column("tokenResetMDP")]
        [StringLength(50)]
        public string? TokenResetMDP { get; set; }

        [Column("dateCreationToken")]
        public DateTime? DateCreationToken { get; set; }

        // Navigation properties
        [ForeignKey("idRole")]
        [InverseProperty(nameof(Role.Clients))]
        public virtual Role? Role { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Adresse.Client))]
        public virtual ICollection<Adresse> Adresses { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Commande.Client))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Commande.ClientBeneficaire))]
        public virtual ICollection<Commande> CommandesOfferts { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Avis.Client))]
        public virtual ICollection<Avis> Avis { get; set; } = new List<Avis>();

        [InverseProperty(nameof(CarteBancaire.Client))]
        public virtual ICollection<CarteBancaire> CartesBancaires { get; set; } = new List<CarteBancaire>();
    }
}
