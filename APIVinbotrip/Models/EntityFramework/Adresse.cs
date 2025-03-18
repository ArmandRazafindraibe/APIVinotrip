using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("adresse")]
    public partial class Adresse
    {
        [Key]
        [Column("idadresse")]
        public int IdAdresse { get; set; }

        [Column("idclient")]
        public int? IdClient { get; set; }

        [Column("idpartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("nomadressedestination")]
        [StringLength(50)]
        public string? PrenomAdresseDestination { get; set; }

        [Column("prenomadressedestinataire")]
        [StringLength(50)]
        public string? NomAdresseDestinataire { get; set; }

        [Column("rueadresse")]
        [StringLength(100)]
        public string? RueAdresse { get; set; }

        [Column("villeadresse")]
        [StringLength(50)]
        public string? VilleAdresse { get; set; }

        [Column("paysadresse")]
        [StringLength(50)]
        public string? PaysAdresse { get; set; }

        [Column("cpadresse")]
        [StringLength(8)]
        public string? CpAdresse { get; set; }

        [Column("nomadresse")]
        [StringLength(50)]
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
        [InverseProperty(nameof(EstProposePar.IdadresseNavigation))]
        public virtual ICollection<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();

    }
}
