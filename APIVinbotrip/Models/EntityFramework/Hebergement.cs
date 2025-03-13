using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("hebergement")]
    public partial class Hebergement
    {
        [Key]
        [Column("idhebergement")]
        public int Idhebergement { get; set; }

        [Column("idpartenaire")]
        public int Idpartenaire { get; set; }

        [Column("descriptionhebergement")]
        [StringLength(4096)]
        public string? Descriptionhebergement { get; set; }

        [Column("photohebergement")]
        [StringLength(512)]
        public string? Photohebergement { get; set; }

        [Column("lienhebergement")]
        [StringLength(512)]
        public string? Lienhebergement { get; set; }

        [Column("prixhebergement")]
        [Precision(8, 2)]
        public decimal? Prixhebergement { get; set; }

        [InverseProperty("IdhebergementNavigation")]
        public virtual ICollection<Descriptioncommande> Descriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [InverseProperty("IdhebergementNavigation")]
        public virtual ICollection<Descriptionpanier> Descriptionpaniers { get; set; } = new List<Descriptionpanier>();

        [InverseProperty("IdhebergementNavigation")]
        public virtual ICollection<Etape> Etapes { get; set; } = new List<Etape>();

        [ForeignKey("Idpartenaire")]
        [InverseProperty("Hebergements")]
        public virtual Hotel IdpartenaireNavigation { get; set; } = null!;
    }
}
