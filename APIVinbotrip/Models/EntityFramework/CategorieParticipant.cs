using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categorieeparticipant")]
    public partial class CategorieParticipant
    {
        [Key]
        [Column("idcategorieparticipant")]
        public int IdCategorieParticipant { get; set; }

        [Column("libellecategorieparticipant")]
        [StringLength(50)]
        public string? LibelleCategorieParticipant { get; set; }
 
        [InverseProperty(nameof(Sejour.IdcategorieparticipantNavigation))]
        public virtual List<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
