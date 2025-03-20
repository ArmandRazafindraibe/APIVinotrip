using APIVinotrip.Models.EntityFramework.APIVinotrip.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("activite")]
    public partial class Activite
    {

        [Key]
        [Column("idactivite")]
        public int IdActivite { get; set; }

        [Column("libelleactivite")]
        [StringLength(100)]
        public string? LibelleActivite { get; set; }

        [Column("prixactivite", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixActivite { get; set; }

        [InverseProperty(nameof(Comporte.UneActivite))]
        public virtual List<Comporte> ListeActivites { get; set; } = new List<Comporte>();

        [InverseProperty(nameof(EstProposePar.IdactiviteNavigation))]
        public virtual List<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();

        [InverseProperty(nameof(Constitue.LActivite))]
        public virtual List<Constitue> Constitues { get; set; } = new List<Constitue>();

        [InverseProperty(nameof(Possede.LActivite))]
        public virtual List<Possede> LesPossedes { get; set; } = new List<Possede>();
    }
}
