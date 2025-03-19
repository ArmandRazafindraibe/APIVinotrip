using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("FAVORIS")]
    public partial class Favoris
    {
        [Key]
        [Column("idClient")]
        public int  IdClient{ get; set; }

        [Key]
        [Column("idSejour")]
        public int IdSejour { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.ListeFavoris))]
        public virtual ICollection<Client> Clients { get; set; }=new List<Client>();


        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.ListeFavoris))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }
}
