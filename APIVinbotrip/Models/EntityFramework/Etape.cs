using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("etape")]
    public partial class Etape
    {
        [Key]
        [Column("idetape")]
        public int Idetape { get; set; }

        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("idhebergement")]
        public int Idhebergement { get; set; }

        [Column("titreetape")]
        [StringLength(100)]
        public string? Titreetape { get; set; }

        [Column("descriptionetape")]
        [StringLength(4096)]
        public string? Descriptionetape { get; set; }

        [Column("photoetape")]
        [StringLength(512)]
        public string? Photoetape { get; set; }

        [Column("urletape")]
        [StringLength(150)]
        public string? Urletape { get; set; }

        [Column("videoetape")]
        [StringLength(512)]
        public string? Videoetape { get; set; }

        [ForeignKey("Idhebergement")]
        [InverseProperty("Etapes")]
        public virtual Hebergement IdhebergementNavigation { get; set; } = null!;

        [ForeignKey("Idsejour")]
        [InverseProperty("Etapes")]
        public virtual Sejour IdsejourNavigation { get; set; } = null!;

        [ForeignKey("Idetape")]
        [InverseProperty("Idetapes")]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();

        [ForeignKey("Idetape")]
        [InverseProperty("Idetapes")]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();

        [ForeignKey("Idetape")]
        [InverseProperty("Idetapes")]
        public virtual ICollection<Visite> Idvisites { get; set; } = new List<Visite>();
    }
}
