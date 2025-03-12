using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.Entity_Framework;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("ADRESSE")]
    public partial class Adresse
    {
        [Key]
        [Column("idAdresse")]
        public int IdAdresse { get; set; }

        [Column("nAdresse")]
        [StringLength(50)]
        public string? NAdresse { get; set; }

        [Column("idClient")]
        public int? IdClient { get; set; }

        [Column("idPartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("nomAdresseDestinationFacture")]
        [StringLength(50)]
        public string? NomAdresseDestinationFacture { get; set; }

        [Column("nomAdresseDestinataire")]
        [StringLength(50)]
        public string? NomAdresseDestinataire { get; set; }

        [Column("rueAdresse")]
        [StringLength(100)]
        public string? RueAdresse { get; set; }

        [Column("villeAdresse")]
        [StringLength(50)]
        public string? VilleAdresse { get; set; }

        [Column("paysAdresse")]
        [StringLength(50)]
        public string? PaysAdresse { get; set; }

        [Column("cpAdresse")]
        [StringLength(8)]
        public string? CpAdresse { get; set; }

        [Column("nomAdresse")]
        [StringLength(10)]
        public string? NomAdresse { get; set; }

        
        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.Adresses))]
        public virtual Client? Client { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.AdressesPartenaires))]
        public virtual Partenaire? Partenaire { get; set; }

        [InverseProperty(nameof(Commande.AdresseLivraison))]
        public virtual ICollection<Commande> CommandesLivraison { get; set; } = new List<Commande>();

        [InverseProperty(nameof(Commande.AdresseFacturation))]
        public virtual ICollection<Commande> CommandesFacturation { get; set; } = new List<Commande>();

        [InverseProperty(nameof(EstProposePar.SeTrouvant))]
        public virtual ICollection<EstProposePar> AdresseActivite { get; set; } = new List<EstProposePar>();
    }
}
