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
        public virtual ICollection<Repas>? RepasDetient { get; set; } = new List<Repas>();

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(DescriptionPanier.DetientCollection))]
        public virtual ICollection<DescriptionPanier> DescriptionPanierDetient { get; set; } = new List<DescriptionPanier>();
    }
}   
