using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("EST_PROPOSE_PAR")]
    public partial class EstProposePar
    {
        [Key]
        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Key]
        [Column("idActivite")]
        public int IdActivite { get; set; }

        [Key]
        [Column("idAdresse")]
        public int IdAdresse { get; set; }

        [ForeignKey("idPartenaire")]
        [InverseProperty(nameof(Partenaire.PartenaireProposant))]
        public Partenaire? Partenaire { get; set; }

        [ForeignKey("idActivite")]
        [InverseProperty(nameof(Activite.PartenaireProposant))]
        public Activite? Activite { get; set; }

        [ForeignKey("idAdresse")]
        [InverseProperty(nameof(Adresse.AdresseActivite))]
        public Activite? Activite { get; set; }
    }
}
