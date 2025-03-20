using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("DETIENT")]
    public partial class Detient
    {
        [Key]
        [Column("idRepas")]
        public int IdRepas { get; set; }

        [Key]
        [Column("idDescriptionPanier")]
        public int IdDescriptionPanier { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.DetientCollection))]
        public virtual Repas? RepasDetient { get; set; } 

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(DescriptionPanier.DetientCollection))]
        public virtual DescriptionPanier? DescriptionPanierDetient { get; set; }
    }
}   
