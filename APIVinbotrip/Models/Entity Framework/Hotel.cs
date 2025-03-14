using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("HOTEL")]
    public partial class Hotel
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

        [Column("nombreChambresHotel")]
        public int? NombreChambresHotel { get; set; }

        [Column("categorieHotel")]
        public int? CategorieHotel { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.HotelPartenaire))]
        public virtual Partenaire? Partenaire { get; set; }

        [InverseProperty(nameof(Hebergement.HebergementHotel))]
        public virtual Partenaire? HotelHebergement { get; set; }

        [InverseProperty(nameof(Hebergement.IdPartenaire))]
       public virtual ICollection<Hebergement> Hebergements { get; set; } = new List<Hebergement>();
    }
}
