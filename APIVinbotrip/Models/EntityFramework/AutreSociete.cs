using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("autresociete")]
    public partial class AutreSociete
    {
        [Key]
        [Column("idpartenaire")]
        public int IdPartenaire { get; set; }

        [Column("nompartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailpartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? Telpartenaire { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.AutreSocietePartenaire))]
        public virtual Partenaire? Partenaire { get; set; }


        [InverseProperty(nameof(EstProposePar.IdpartenaireNavigation))]
        public virtual ICollection<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();
    }
}
