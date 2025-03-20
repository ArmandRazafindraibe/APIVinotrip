using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("duree")]
    public partial class Duree
    {
        [Key]
        [Column("idduree")]
        public int IdDuree { get; set; }

        [Column("libelleduree")]
        [StringLength(50)]
        public string? LibelleDuree { get; set; }

        [InverseProperty(nameof(Sejour.IddureeNavigation))]
        public virtual List<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
