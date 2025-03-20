using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("detient")]
    public partial class Detient
    {
        [Key]
        [Column("idrepas")]
        public int IdRepas { get; set; }

        [Key]
        [Column("iddescriptionpanier")]
        public int IdDescriptionPanier { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.DetientCollection))]
        public virtual Repas? RepasDetient { get; set; } 

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(DescriptionPanier.DetientCollection))]
        public virtual DescriptionPanier? DescriptionPanierDetient { get; set; }
    }
}   
