using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("FAVORIS")]
    public partial class Favoris
    {
        [Key]
        [Column("idclient")]
        public int  IdClient{ get; set; }

        [Key]
        [Column("idsejour")]
        public int IdSejour { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.ListeFavoris))]
        public virtual Client? LeClient { get; set; }


        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.ListeFavoris))]
        public virtual Sejour? Sejours { get; set; } 
    }
}
