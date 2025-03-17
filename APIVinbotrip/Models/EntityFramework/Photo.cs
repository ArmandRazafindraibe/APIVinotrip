using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("photo")]
    public partial class Photo
    {
        [Key]
        [Column("idphoto")]
        public int IdPhoto { get; set; }

        [Column("idsejour")]
        public int IdSejour { get; set; }

        // Additional properties for Photo

        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.Photos))]
        public virtual Sejour? Sejour { get; set; }
    }
}
