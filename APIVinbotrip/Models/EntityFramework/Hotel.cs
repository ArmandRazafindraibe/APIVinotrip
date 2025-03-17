using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.EntityFramework
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

        //[InverseProperty(nameof(Hebergement.HebergementHotel))]
        //public virtual Hotel? HotelHebergement { get; set; }

        [InverseProperty(nameof(Hebergement.HebergementHotel))]
       public virtual ICollection<Hebergement> HotelHebergements { get; set; } = new List<Hebergement>();
    }
}
