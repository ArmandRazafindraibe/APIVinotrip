using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("photos")]
    public partial class Photo
    {
        [Key]
        [Column("idphoto")]
        public int Idphoto { get; set; }

        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("photo")]
        [StringLength(512)]
        public string? Photo1 { get; set; }

        [ForeignKey("Idsejour")]
        [InverseProperty("Photos")]
        public virtual Sejour IdsejourNavigation { get; set; } = null!;
    }

}
