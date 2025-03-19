using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    public class Mange1
    {
        [Key]
        [Column("idrepas")]
        public int IdRepas { get; set; }

        [Key]
        [Column("iddescriptioncommande")]
        public int IdDescriptionCommande { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.Mange1s))]
        public virtual Repas Repas { get; set; } = null!;

        [ForeignKey(nameof(IdDescriptionCommande))]
        [InverseProperty(nameof(DescriptionCommande.Mange1s))]
        public virtual DescriptionCommande DescriptionCommande { get; set; } = null!;
    }
}
