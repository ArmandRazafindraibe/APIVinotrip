using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("repas")]
    public partial class Repas
    {
        [Key]
        [Column("idrepas")]
        public int IdRepas { get; set; }

        [Column("idpartenaire")]
        public int? IdPartenaire { get; set; }

        [Column("descriptionrepas")]
        [StringLength(4096)]
        public string? DescriptionRepas { get; set; }

        [Column("photorepas")]
        [StringLength(512)]
        public string? PhotoRepas { get; set; }

        [Column("prixrepas", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixRepas { get; set; }


        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Restaurant.RepasCollection))]
        public virtual Restaurant? RestaurantRepas { get; set; }

        [InverseProperty(nameof(Inclus.Repas))]
        public virtual Inclus? Inclusions { get; set; }

        [InverseProperty(nameof(Detient.RepasDetient))]
        public virtual List<Detient> DetientCollection { get; set; } = new List<Detient>();

        [InverseProperty(nameof(Mange1.UnRepas))]
        public virtual List<Mange1> RepasManges { get; set; } = new List<Mange1>();    
    }
}