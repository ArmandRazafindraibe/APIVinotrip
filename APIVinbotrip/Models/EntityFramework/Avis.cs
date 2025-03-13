using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("avis")]
    public partial class Avi
    {
        [Key]
        [Column("idavis")]
        public int Idavis { get; set; }

        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("idclient")]
        public int Idclient { get; set; }

        [Column("titreavis")]
        [StringLength(50)]
        public string? Titreavis { get; set; }

        [Column("dateavis")]
        public DateOnly? Dateavis { get; set; }

        [Column("descriptionavis")]
        [StringLength(2048)]
        public string? Descriptionavis { get; set; }

        [Column("noteavis")]
        public int? Noteavis { get; set; }

        [Column("photoavis")]
        [StringLength(512)]
        public string? Photoavis { get; set; }

        [ForeignKey("Idclient")]
        [InverseProperty("Avis")]
        public virtual Client IdclientNavigation { get; set; } = null!;

        [ForeignKey("Idsejour")]
        [InverseProperty("Avis")]
        public virtual Sejour IdsejourNavigation { get; set; } = null!;

        [InverseProperty("IdavisNavigation")]
        public virtual ICollection<Reponse> Reponses { get; set; } = new List<Reponse>();
    }
}
