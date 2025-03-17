using APIVinbotrip.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("ACTIVITE")]
    public partial class Activite
    {

        [Key]
        [Column("idActivite")]
        public int IdActivite { get; set; }

        [Column("libelleActivite")]
        [StringLength(100)]
        public string? LibelleActivite { get; set; }

        [Column("prixActivite", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixActivite { get; set; }
        [InverseProperty("IdactiviteNavigation")]
        public virtual ICollection<EstProposePar> Proposes { get; set; } = new List<EstProposePar>();

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(DescriptionCommande))]
        public virtual ICollection<DescriptionCommande> DescriptionCommandes { get; set; } = new List<DescriptionCommande>();

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(DescriptionPanier.Idactivites))]
        public virtual ICollection<DescriptionPanier> Iddescriptionpaniers { get; set; } = new List<DescriptionPanier>();

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty("Idactivites")]
        public virtual ICollection<Etape> Idetapes { get; set; } = new List<Etape>();
        [InverseProperty("IdactiviteNavigation")]
        public virtual ICollection<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();


    }
}
