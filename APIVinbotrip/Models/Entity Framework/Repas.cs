using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinbotrip.Models.Entity_Framework;

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
        [StringLength(4098)]
        public string? DescriptionRepas { get; set; }

        [Column("photoRepas")]
        [StringLength(512)]
        public string? PhotoRepas { get; set; }

        [Column("prixRepas", TypeName = "decimal(8,2)")]
        public decimal PrixRepas { get; set; }

        [ForeignKey("IdPartenaire")]
        [InverseProperty(nameof(Partenaire.Repas))]
        public virtual Partenaire? Partenaire { get; set; }
    }
}
