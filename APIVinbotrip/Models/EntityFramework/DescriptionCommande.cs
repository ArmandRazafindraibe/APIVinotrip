using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.EntityFramework.APIVinotrip.Models.EntityFramework;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("descriptioncommande")]
    public partial class DescriptionCommande
    {
        [Key]
        [Column("iddescriptioncommande")]
        public int IdDescriptionCommande { get; set; }

        [Column("idcommande")]
        public int? IdCommande { get; set; }

        [Column("idhebergement")]
        public int? IdHebergement { get; set; }

        [Column("idpassegeiment")]
        public int? IdPassegeiment { get; set; }

        [Column("idsejour")]
        public int? IdSejour { get; set; }

        [Column("quantite")]
        public int? Quantite { get; set; }

        [Column("idcb")]
        public int? IdCB { get; set; }


        [Column("datedebut")]
        public DateTime? DateDebut { get; set; }

        [Column("datefin")]
        public DateTime? DateFin { get; set; }

        [Column("nbadultes")]
        public int? NbAdultes { get; set; }

        [Column("nbenfants")]
        public int? NbEnfants { get; set; }

        [Column("nbchambressimple")]
        public int? NbChambresSimple { get; set; }

        [Column("nbchambresdouble")]
        public int? NbChambresDouble { get; set; }

        [Column("nbchambrestriple")]
        public int? NbChambresTriple { get; set; }

        [Column("offrir")]
        public bool? EncaissementMangement { get; set; }

        [Column("ecoffret")]
        public bool? ECoffret { get; set; }

        [Column("disponibiliteHebergement")]
        public bool? DisponibiliteHebergement { get; set; }

        [Column("validationclient")]
        public bool? ValidationClient { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.DescriptionsCommande))]
        public virtual Commande? Commande { get; set; }

        [ForeignKey(nameof(IdDescriptionCommande))]
        [InverseProperty(nameof(Activite.DescriptionCommandes))]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();



        [ForeignKey(nameof(IdCB))]
        [InverseProperty(nameof(CarteBancaire.DescriptionsCommande))]
        public virtual CarteBancaire? DescriptionsCommandeCB { get; set; }


        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.DescriptioncommandesNavigation))]
        public virtual Sejour? Sejours { get; set; }


        [ForeignKey(nameof(IdHebergement))]
        [InverseProperty(nameof(Hebergements.DescriptionsCommande))]
        public virtual Hebergement? Hebergements { get; set; }


        [InverseProperty(nameof(Mange1.DescriptionCommande))]
        public virtual ICollection<Mange1> RepasCommandes { get; set; } = null!;

        //[InverseProperty(nameof(Commande.DescriptionsCommande))]
        //public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [ForeignKey(nameof(IdDescriptionCommande))]
        [InverseProperty(nameof(Repas.Iddescriptioncommandes))]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();

        [InverseProperty(nameof(Possede.LaDescriptionCommande))]
        public virtual ICollection<Possede> LesPossedes { get; set; } = null!;

    }

}
