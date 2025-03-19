using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("partenaire")]
    public partial class Partenaire
    {
        [Key]
        [Column("idpartenaire")]
        public int IdPartenaire { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? TelPartenaire { get; set; }

        // Collection navigation properties

        [InverseProperty(nameof(Restaurant.Partenaire))]
        public virtual Restaurant? Restaurants { get; set; } 

        [InverseProperty(nameof(Cave.Partenaire))]
        public virtual Cave? Caves { get; set; } 

        [InverseProperty(nameof(Adresse.Partenaire))]
        public virtual ICollection<Adresse> AdressesPartenaires { get; set; } = new List<Adresse>();

        [InverseProperty(nameof(Hotel.Partenaire))]
        public virtual Hotel? HotelPartenaire { get; set; }

        [InverseProperty(nameof(AutreSociete.Partenaire))]
        public virtual AutreSociete? AutreSocietePartenaire { get; set; }
    }
}
