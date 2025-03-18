using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("carte_bancaire")]
    public partial class CarteBancaire
    {
        [Key]
        [Column("idcb")]
        public int IdCB { get; set; }

        [Column("idclient")]
        public int? IdClient { get; set; }

        [Column("titulairecb")]
        [StringLength(100)]
        public string? titulaireCb { get; set; }

        [Column("numerocb")]
        [StringLength(50)]
        public string? NumeroCB { get; set; }

        [Column("numerocvccarte")]
        [StringLength(5)]
        public string? NumeroCVCCarte { get; set; }

        [Column("dateexpirationcreditcard")]
        public DateTime? DateExpirationCreditCard { get; set; }

        [Column("actif")]
        public bool? Actif { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.CartesBancaires))]
        public virtual Client? Client { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Commande.CarteBancaire))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty(nameof(DescriptionCommande.DescriptionsCommandeCB))]
        public virtual ICollection<DescriptionCommande> DescriptionsCommande { get; set; }=new List<DescriptionCommande>();
    }
}
