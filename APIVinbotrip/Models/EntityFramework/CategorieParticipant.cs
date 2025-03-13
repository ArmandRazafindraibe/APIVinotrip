using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categorieparticipant")]
   
    public partial class Categorieparticipant
    {
        [Key]
        [Column("idcategorieparticipant")]
        public int Idcategorieparticipant { get; set; }

        [Column("libellecategorieparticipant")]
        [StringLength(50)]
        public string? Libellecategorieparticipant { get; set; }

        [InverseProperty("IdcategorieparticipantNavigation")]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
