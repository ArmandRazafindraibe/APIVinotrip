using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

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

        [Column("prixsejour",TypeName = "NUMERIC(8,2)")]
        public decimal? Prixsejour { get; set; }

        [Column("publie")]
        public bool? Publie { get; set; }

        [Column("nouveauprixsejour", TypeName = "NUMERIC(8,2)")]
        public decimal? Nouveauprixsejour { get; set; }

        [InverseProperty(nameof(Avis.Sejour))]
        public virtual ICollection<Avis> AvisNavigation { get; set; } = new List<Avis>();

        [InverseProperty(nameof(DescriptionCommande.Sejours))]
        public virtual ICollection<DescriptionCommande> DescriptioncommandesNavigation { get; set; } = new List<DescriptionCommande>();

        [InverseProperty(nameof(DescriptionPanier.Sejour))]
        public virtual ICollection<DescriptionPanier> Descriptionpaniers { get; set; } = new List<DescriptionPanier>();

        [InverseProperty(nameof(Etape.Sejour))]
        public virtual ICollection<Etape> Etapes { get; set; } = new List<Etape>();

        [ForeignKey(nameof(Idcategorieparticipant))]
        [InverseProperty(nameof(CategorieParticipant.Sejours))]
        public virtual CategorieParticipant IdcategorieparticipantNavigation { get; set; } = null!;

        [ForeignKey(nameof(Idcategoriesejour))]
        [InverseProperty(nameof(CategorieSejour.Sejours))]
        public virtual CategorieSejour IdcategoriesejourNavigation { get; set; } = null!;

        [ForeignKey(nameof(Idcategorievignoble))]
        [InverseProperty(nameof(CategorieVignoble.Sejours))]
        public virtual CategorieVignoble IdcategorievignobleNavigation { get; set; } = null!;

        [ForeignKey(nameof(Idduree))]
        [InverseProperty(nameof(Duree.Sejours))]
        public virtual Duree IddureeNavigation { get; set; } = null!;

        [ForeignKey(nameof(Idlocalite))]
        [InverseProperty(nameof(Localite.Sejours))]
        public virtual Localite? IdlocaliteNavigation { get; set; }

        [ForeignKey(nameof(Idtheme))]
        [InverseProperty(nameof(Theme.Sejours))]
        public virtual Theme IdthemeNavigation { get; set; } = null!;

        [InverseProperty(nameof(Photo.Sejour))]
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

        [ForeignKey(nameof(Idsejour))]
        [InverseProperty(nameof(Client.Idsejours))]
        public virtual ICollection<Client> Idclients { get; set; } = new List<Client>();

        
        [InverseProperty(nameof(Favoris.Sejours))]
        public virtual ICollection<Favoris> ListeFavoris { get; set; } = new List<Favoris>();

    }

}