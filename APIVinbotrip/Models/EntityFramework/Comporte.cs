using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("comporte")]
    public partial class Comporte
    {
        [Key]
        [Column("idactivite")]
        public int IdActivite { get; set; }

        [Key]
        [Column("iddescriptionpanier")]
        public int IdDescriptionPanier { get; set; }

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Activite.ListeActivites))]
        public virtual Activite? ActiviteComportant { get; set; }

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(DescriptionPanier.ListeDescriptions))]
        public virtual DescriptionPanier? DescriptionPanierComporte { get; set; }
    }
}
