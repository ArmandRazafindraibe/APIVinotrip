using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("REPAS")]
    public partial class Repas
    {
        [Key]
        [Column("idRepas")]
        public int IdRepas { get; set; }

        [Column("idPartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("descriptionRepas")]
        [StringLength(4096)]
        public string? DescriptionRepas { get; set; }

        [Column("photoRepas")]
        [StringLength(512)]
        public string? PhotoRepas { get; set; }

        [Column("prixRepas", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixRepas { get; set; }


        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Restaurant.RepasCollection))]
        public virtual Restaurant? RestaurantRepas { get; set; }


     
    }
}