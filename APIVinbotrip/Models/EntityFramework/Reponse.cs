using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("reponse")]
    public partial class Reponse
    {
        [Key]
        [Column("idreponse")]
        public int Idreponse { get; set; }

        [Column("idavis")]
        public int Idavis { get; set; }

        [Column("descriptionreponse")]
        [StringLength(4096)]
        public string? Descriptionreponse { get; set; }

        [ForeignKey("Idavis")]
        [InverseProperty("Reponses")]
        public virtual Avi IdavisNavigation { get; set; } = null!;
    }

}
