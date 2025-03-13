using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("repas")]

    public partial class Repas
    {
        [Key]
        [Column("idrepas")]
        public int Idrepas { get; set; }

        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("descriptionrepas")]
        [StringLength(4096)]
        public string? Descriptionrepas { get; set; }

        [Column("photorepas")]
        [StringLength(512)]
        public string? Photorepas { get; set; }

        [Column("prixrepas")]
        [Precision(8, 2)]
        public decimal? Prixrepas { get; set; }

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Repas")]
        public virtual Restaurant IdpartenaireNavigation { get; set; } = null!;

        [ForeignKey("Idrepas")]
        [InverseProperty("Idrepas")]
        public virtual ICollection<Descriptioncommande> Iddescriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [ForeignKey("Idrepas")]
        [InverseProperty("Idrepas")]
        public virtual ICollection<Descriptionpanier> Iddescriptionpaniers { get; set; } = new List<Descriptionpanier>();

        [ForeignKey("Idrepas")]
        [InverseProperty("Idrepas")]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();
    }
}