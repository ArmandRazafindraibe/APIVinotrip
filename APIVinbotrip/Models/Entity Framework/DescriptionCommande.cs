using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.Entity_Framework;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("DESCRIPTIONCOMMANDE")]
    public partial class DescriptionCommande
    {
        [Key]
        [Column("idDescriptionCommande")]
        public int IdDescriptionCommande { get; set; }

        [Column("idCommande")]
        public int? IdCommande { get; set; }

        [Column("idHebergement")]
        public int? IdHebergement { get; set; }

        [Column("idPassegeiment")]
        public int? IdPassegeiment { get; set; }

        [Column("idSejour")]
        public int? IdSejour { get; set; }

        [Column("quantite")]
        public int? Quantite { get; set; }

        [Column("idCB")]
        public int? IdCB { get; set; }

        [Column("quantite")]
        public int? Quantite2 { get; set; }

        [Column("prixOeuf")]
        public int? PrixOeuf { get; set; }

        [Column("dateFin")]
        public DateTime? DateFin { get; set; }

        [Column("nbAdultes")]
        public int? NbAdultes { get; set; }

        [Column("nbEnfants")]
        public int? NbEnfants { get; set; }

        [Column("nbChambresSimple")]
        public int? NbChambresSimple { get; set; }

        [Column("nbChambresDouble")]
        public int? NbChambresDouble { get; set; }

        [Column("nbChambresTriple")]
        public int? NbChambresTriple { get; set; }

        [Column("pDej")]
        public bool? PDej { get; set; }

        [Column("isPDej")]
        public bool? IsPDej { get; set; }

        [Column("encaissementMangement")]
        public bool? EncaissementMangement { get; set; }

        [Column("validationClient")]
        public bool? ValidationClient { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.DescriptionsCommande))]
        public virtual Commande? Commande { get; set; }

        

        [ForeignKey(nameof(IdCB))]
        [InverseProperty(nameof(CarteBancaire.DescriptionsCommande))]
        public virtual CarteBancaire? CarteBancaire { get; set; }


        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.DescriptionsCommande))]
        public virtual Sejour? Sejours { get; set; }


        [ForeignKey(nameof(IdHebergement))]
        [InverseProperty(nameof(Hebergement.DescriptionsCommande))]
        public virtual Hebergement? Hebergements { get; set; }




        [InverseProperty(nameof(Commande.DescriptionsCommande))]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
