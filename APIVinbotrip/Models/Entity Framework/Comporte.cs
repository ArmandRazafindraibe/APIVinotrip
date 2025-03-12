using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIVinotrip.Models.Entity_Framework;
using System.Diagnostics;
using APIVinbotrip.Models.Entity_Framework;

namespace APIVinotrip.Models.Entity_Framework
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
