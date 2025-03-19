using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    public partial class Mange1
    {
        [Key]
        [Column("idrepas")]
        public int IdRepas { get; set; }

        [Key]
        [Column("iddescriptioncommande")]
        public int IdDescriptionCommande { get; set; }

        [ForeignKey(nameof(IdRepas))]
        [InverseProperty(nameof(Repas.RepasManges))]
        public virtual Repas UnRepas { get; set; } = null!;

        [ForeignKey(nameof(IdDescriptionCommande))]
        [InverseProperty(nameof(DescriptionCommande.RepasCommandes))]
        public virtual DescriptionCommande DescriptionCommande { get; set; } = null!;
    }
}
