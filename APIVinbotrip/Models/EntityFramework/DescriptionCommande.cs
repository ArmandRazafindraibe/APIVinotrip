using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("descriptioncommande")]
    public partial class Descriptioncommande
    {
        [Key]
        [Column("iddescriptioncommande")]
        public int Iddescriptioncommande { get; set; }

        [Column("idcommande")]
        public int Idcommande { get; set; }

        [Column("idhebergement")]
        public int Idhebergement { get; set; }

        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("idcb")]
        public int? Idcb { get; set; }

        [Column("quantite")]
        public int? Quantite { get; set; }

        [Column("datedebut")]
        public DateOnly? Datedebut { get; set; }

        [Column("datefin")]
        public DateOnly? Datefin { get; set; }

        [Column("nbadultes")]
        public int? Nbadultes { get; set; }

        [Column("nbenfants")]
        public int? Nbenfants { get; set; }

        [Column("nbchambressimple")]
        public int? Nbchambressimple { get; set; }

        [Column("nbchambresdouble")]
        public int? Nbchambresdouble { get; set; }

        [Column("nbchambrestriple")]
        public int? Nbchambrestriple { get; set; }

        [Column("offrir")]
        public bool? Offrir { get; set; }

        [Column("ecoffret")]
        public bool? Ecoffret { get; set; }

        [Column("disponibilitehebergement")]
        public bool? Disponibilitehebergement { get; set; }

        [Column("validationclient")]
        public bool? Validationclient { get; set; }

        [ForeignKey("Idcb")]
        [InverseProperty("Descriptioncommandes")]
        public virtual CarteBancaire? IdcbNavigation { get; set; }

        [ForeignKey("Idcommande")]
        [InverseProperty("Descriptioncommandes")]
        public virtual Commande IdcommandeNavigation { get; set; } = null!;

        [ForeignKey("Idhebergement")]
        [InverseProperty("Descriptioncommandes")]
        public virtual Hebergement IdhebergementNavigation { get; set; } = null!;

        [ForeignKey("Idsejour")]
        [InverseProperty("Descriptioncommandes")]
        public virtual Sejour IdsejourNavigation { get; set; } = null!;

        [ForeignKey("Iddescriptioncommande")]
        [InverseProperty("Iddescriptioncommandes")]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();

        [ForeignKey("Iddescriptioncommande")]
        [InverseProperty("Iddescriptioncommandes")]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();
    }
}

