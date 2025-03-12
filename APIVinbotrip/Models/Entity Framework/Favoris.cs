using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("FAVORIS")]
    public partial class Favoris
    {
        [Key]
        [Column("idFavoris")]
        public int  IdFavoris{ get; set; }




    }
}
