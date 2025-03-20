using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("categorievignoble")]
    public partial class CategorieVignoble
    {
        [Key]
        [Column("idcategorievignoble")]
        public int IdCategorieVignoble { get; set; }

        [Column("libellecategorievignoble")]
        [StringLength(50)]
        public string? LibelleCategorieVignoble { get; set; }

        // Collection navigation properties
        [InverseProperty(nameof(Localite.CategoriesVignoble))]
        public virtual ICollection<Localite> Localites { get; set; } = new List<Localite>();

        [InverseProperty(nameof(Sejour.IdcategorievignobleNavigation))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();

        [InverseProperty(nameof(SeLocalise.CategoriesVignoble))]
        public virtual ICollection<SeLocalise> SesLocalites { get; set; } = new List<SeLocalise>();

    }
}
