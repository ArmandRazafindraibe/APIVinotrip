using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("COMMANDE")]
    public partial class Commande
    {
        [Key]
        [Column("idCommande")]
        public int IdCommande { get; set; }

        [Column("referenceCommande")]
        [StringLength(20)]
        public string? ReferenceCommande { get; set; }

        [Column("idCB")]
        public int? IdCB { get; set; }

        [Column("idClient")]
        public int? IdClient { get; set; }

        [Column("idAdresseLivraison")]
        public int? IdAdresseLivraison { get; set; }

        [Column("idCommentaire")]
        public int? IdCommentaire { get; set; }

        [Column("codeReduction")]
        [StringLength(20)]
        public string? CodeReduction { get; set; }

        [Column("idDescriptionClient")]
        public int? IdDescriptionClient { get; set; }

        [Column("prixTotalCommande")]
        [StringLength(50)]
        public string? PrixTotalCommande { get; set; }

        [Column("typePayementCommande")]
        [StringLength(50)]
        public string? TypePayementCommande { get; set; }

        [Column("dateCommande")]
        public DateTime? DateCommande { get; set; }

        // Navigation properties
        [ForeignKey("IdClient")]
        [InverseProperty(nameof(Client.Commandes))]
        public virtual Client? Client { get; set; }

        [ForeignKey("IdCB")]
        [InverseProperty(nameof(CarteBancaire.Commandes))]
        public virtual CarteBancaire? CarteBancaire { get; set; }

        [ForeignKey("IdDescriptionClient")]
        [InverseProperty(nameof(DescriptionCommande.Commandes))]
        public virtual DescriptionCommande? DescriptionCommande { get; set; }

        [ForeignKey("IdAdresseLivraison")]
        [InverseProperty(nameof(Adresse.CommandesLivraison))]
        public virtual Adresse? AdresseLivraison { get; set; }

        [InverseProperty(nameof(DescriptionCommande.Commande))]
        public virtual ICollection<DescriptionCommande> DescriptionsCommande { get; set; } = new List<DescriptionCommande>();

        // Add other possible collection navigation properties as needed based on the diagram
    }
}
