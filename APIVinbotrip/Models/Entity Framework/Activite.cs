using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.Entity_Framework
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

       

    }
}
