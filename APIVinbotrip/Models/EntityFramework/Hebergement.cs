
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("HEBERGEMENT")]
    public partial class Hebergement
    {
        [Key]
        [Column("idHebergement")]
        public int IdHebergement { get; set; }

        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Column("descriptionHebergement")]
        [StringLength(4096)]
        public string? DescriptionHebergement { get; set; }

        [Column("photoHebergement")]
        [StringLength(512)]
        public string? PhotoHebergement { get; set; }

        [Column("lienHebergement")]
        [StringLength(512)]
        public string? LienHebergement { get; set; }

        [Column("prixHebergement", TypeName ="NUMERIC(8,2)")]
        public decimal? PrixHebergement { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Hotel.HotelHebergements))]
        public virtual Hotel? HebergementHotel { get; set; }

        [InverseProperty(nameof(Etape.Hebergement))]
        public virtual ICollection<Etape>? Etapes { get; set; }

        [InverseProperty(nameof(DescriptionPanier.Hebergement))]
        public virtual ICollection<DescriptionPanier>? DescriptionsPanier { get; set; }

        [InverseProperty(nameof(DescriptionCommande.Hebergements))]
        public virtual ICollection<DescriptionCommande>? DescriptionsCommande { get; set; }
    }
}
