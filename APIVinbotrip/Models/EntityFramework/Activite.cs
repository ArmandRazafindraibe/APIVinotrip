using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [InverseProperty(nameof(Comporte.ActiviteComporte))]
        public virtual ICollection<Comporte>? ListeActivites { get; set; }

        [InverseProperty(nameof(DescriptionCommande.Idactivites))]
        public virtual ICollection<DescriptionCommande> DescriptionCommandes { get; set; } = new List<DescriptionCommande>();

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(DescriptionPanier.Idactivites))]
        public virtual ICollection<DescriptionPanier> Iddescriptionpaniers { get; set; } = new List<DescriptionPanier>();

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Etape.Idactivites))]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();

        [InverseProperty(nameof(EstProposePar.IdactiviteNavigation))]
        public virtual ICollection<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();

        [InverseProperty(nameof(Constitue.Activites))]
        public virtual ICollection<Constitue> Constitues { get; set; } = null!;


    }
}
