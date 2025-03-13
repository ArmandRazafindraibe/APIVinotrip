using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("codepromo")]
   
    public partial class Codepromo
    {
        [Key]
        [Column("idcodepromo")]
        public int Idcodepromo { get; set; }

        [Column("libellecodepromo")]
        [StringLength(15)]
        public string? Libellecodepromo { get; set; }

        [Column("reduction")]
        public int? Reduction { get; set; }

        [InverseProperty("IdcodepromoNavigation")]
        public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();

        [InverseProperty("IdcodepromoNavigation")]
        public virtual ICollection<Panier> Paniers { get; set; } = new List<Panier>();
    }

}


