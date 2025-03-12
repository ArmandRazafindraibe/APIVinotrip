using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("PARTENAIRE")]
    public partial class Partenaire
    {
        [Key]
        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Column("nomPartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailPartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telPartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Etape.Partenaire))]
        public virtual ICollection<Etape> LesEtapes { get; set; } = new List<Etape>();

        [InverseProperty(nameof(EstProposePar.Partenaire))]
        public virtual Adresse? PartenaireProposant { get; set; } 

        [InverseProperty(nameof(Visite.Partenaire))]
        public virtual ICollection<Visite> Visites { get; set; } = new List<Visite>();

        [InverseProperty(nameof(Repas.Partenaire))]
        public virtual ICollection<Repas> LesRepas { get; set; } = new List<Repas>();

        [InverseProperty(nameof(Restaurant.Partenaire))]
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

        [InverseProperty(nameof(Cave.Partenaire))]
        public virtual ICollection<Cave> Caves { get; set; } = new List<Cave>();

        [InverseProperty(nameof(Adresse.Partenaire))]
        public virtual ICollection<Partenaire> AdressesPartenaires { get; set; } = new List<Partenaire>();
    }
}
