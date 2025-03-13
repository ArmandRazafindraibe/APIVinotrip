using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("sejour")]
    public partial class Sejour
    {
        [Key]
        [Column("idsejour")]
        public int Idsejour { get; set; }

        [Column("idduree")]
        public int Idduree { get; set; }

        [Column("idcategorievignoble")]
        public int Idcategorievignoble { get; set; }

        [Column("idcategoriesejour")]
        public int Idcategoriesejour { get; set; }

        [Column("idlocalite")]
        public int? Idlocalite { get; set; }

        [Column("idtheme")]
        public int Idtheme { get; set; }

        [Column("idcategorieparticipant")]
        public int Idcategorieparticipant { get; set; }

        [Column("titresejour")]
        [StringLength(100)]
        public string? Titresejour { get; set; }

        [Column("photosejour")]
        [StringLength(512)]
        public string? Photosejour { get; set; }

        [Column("descriptionsejour")]
        [StringLength(4096)]
        public string? Descriptionsejour { get; set; }

        [Column("prixsejour")]
        [Precision(8, 2)]
        public decimal? Prixsejour { get; set; }

        [Column("publie")]
        public bool? Publie { get; set; }

        [Column("nouveauprixsejour")]
        [Precision(8, 2)]
        public decimal? Nouveauprixsejour { get; set; }

        [InverseProperty("IdsejourNavigation")]
        public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

        [InverseProperty("IdsejourNavigation")]
        public virtual ICollection<Descriptioncommande> Descriptioncommandes { get; set; } = new List<Descriptioncommande>();

        [InverseProperty("IdsejourNavigation")]
        public virtual ICollection<Descriptionpanier> Descriptionpaniers { get; set; } = new List<Descriptionpanier>();

        [InverseProperty("IdsejourNavigation")]
        public virtual ICollection<Etape> Etapes { get; set; } = new List<Etape>();

        [ForeignKey("Idcategorieparticipant")]
        [InverseProperty("Sejours")]
        public virtual Categorieparticipant IdcategorieparticipantNavigation { get; set; } = null!;

        [ForeignKey("Idcategoriesejour")]
        [InverseProperty("Sejours")]
        public virtual Categoriesejour IdcategoriesejourNavigation { get; set; } = null!;

        [ForeignKey("Idcategorievignoble")]
        [InverseProperty("Sejours")]
        public virtual Categorievignoble IdcategorievignobleNavigation { get; set; } = null!;

        [ForeignKey("Idduree")]
        [InverseProperty("Sejours")]
        public virtual Duree IddureeNavigation { get; set; } = null!;

        [ForeignKey("Idlocalite")]
        [InverseProperty("Sejours")]
        public virtual Localite? IdlocaliteNavigation { get; set; }

        [ForeignKey("Idtheme")]
        [InverseProperty("Sejours")]
        public virtual Theme IdthemeNavigation { get; set; } = null!;

        [InverseProperty("IdsejourNavigation")]
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

        [ForeignKey("Idsejour")]
        [InverseProperty("Idsejours")]
        public virtual ICollection<Client> Idclients { get; set; } = new List<Client>();
    }


}