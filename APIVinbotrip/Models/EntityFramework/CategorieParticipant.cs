using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinbotrip.Models.EntityFramework
{
    [Table("CATEGORIEEPARTICIPANT")]
    public partial class CategorieParticipant
    {
        [Key]
        [Column("idCategorieParticipant")]
        public int IdCategorieParticipant { get; set; }

        [Column("libelleCategorieParticipant")]
        [StringLength(50)]
        public string? LibelleCategorieParticipant { get; set; }
 
        [InverseProperty(nameof(Sejour.IdcategorieparticipantNavigation))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
