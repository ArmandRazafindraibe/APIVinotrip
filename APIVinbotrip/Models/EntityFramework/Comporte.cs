using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("COMPORTE")]
    public partial class Comporte
    {
        [Key]
        [Column("idActivite")]
        public int IdActivite { get; set; }

        [Key]
        [Column("idDescriptionPanier")]
        public int IdDescriptionPanier { get; set; }

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Activite.ListeActivites))]
        public virtual Activite? ActiviteComporte { get; set; }

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(DescriptionPanier.ListeDescriptions))]
        public virtual DescriptionPanier? DescriptionPanierComporte { get; set; }
    }
}
