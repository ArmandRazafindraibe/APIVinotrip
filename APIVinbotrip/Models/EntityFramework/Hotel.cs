using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("hotel")]
    public partial class Hotel
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

        [Column("nombrechambreshotel")]
        public int? NombreChambresHotel { get; set; }

        [Column("categoriehotel")]
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
