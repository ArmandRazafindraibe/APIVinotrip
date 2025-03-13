using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("descriptionpanier")]
    
    public partial class Descriptionpanier
    {
        [Key]
        [Column("iddescriptionpanier")]
        public int Iddescriptionpanier { get; set; }

        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("idhebergement")]
        public int Idhebergement { get; set; }

        [Column("idpanier")]
        public int Idpanier { get; set; }

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

        [ForeignKey("Idhebergement")]
        [InverseProperty("Descriptionpaniers")]
        public virtual Hebergement IdhebergementNavigation { get; set; } = null!;

        [ForeignKey("Idpanier")]
        [InverseProperty("Descriptionpaniers")]
        public virtual Panier IdpanierNavigation { get; set; } = null!;

        [ForeignKey("Idsejour")]
        [InverseProperty("Descriptionpaniers")]
        public virtual Sejour IdsejourNavigation { get; set; } = null!;

        [ForeignKey("Iddescriptionpanier")]
        [InverseProperty("Iddescriptionpaniers")]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();

        [ForeignKey("Iddescriptionpanier")]
        [InverseProperty("Iddescriptionpaniers")]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();
    }
}