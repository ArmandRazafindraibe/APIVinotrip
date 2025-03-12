using APIVinotrip.Models.Entity_Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinbotrip.Models.Entity_Framework
{
    [Table("SEJOUR")]
    public partial class Sejour
    {
        [Key]
        [Column("idSejour")]
        public int IdSejour { get; set; }

        [Column("titreSejour")]
        [StringLength(100)]
        public string? TitreSejour { get; set; }

        [Column("photoSejour")]
        [StringLength(512)]
        public string? PhotoSejour { get; set; }

        [Column("descriptionSejour")]
        [StringLength(4096)]
        public string? DescriptionSejour { get; set; }

        [Column("prixSejour", TypeName = "NUMERIC(8,2)")]
        public decimal? PrixSejour { get; set; }

        [Column("publie")]
        public bool? Publie { get; set; }

        [Column("nouveauPrixSejour", TypeName = "NUMERIC(8,2)")]
        public decimal? NouveauPrixSejour { get; set; }

        [Column("idDuree")]
        public int IdDuree { get; set; }

        [Column("idCategorieVignoble")]
        public int IdCategorieVignoble { get; set; }

        [Column("idLocalite")]
        public int IdLocalite { get; set; }

        [Column("idTheme")]
        public int IdTheme { get; set; }

        [Column("idCategorieSejour")]
        public int IdCategorieSejour { get; set; }

        [Column("idCategorieParticipant")]
        public int IdCategorieParticipant { get; set; }

       
        [InverseProperty(nameof(CategorieSejour.Sejours))]
        public virtual CategorieSejour? CategorieSejour { get; set; }

        [InverseProperty(nameof(DescriptionPanier.Sejour))]
        public virtual ICollection<DescriptionPanier>? DescriptionsPanierSejour { get; set; } = new List<DescriptionPanier>();

        [InverseProperty(nameof(Theme.Sejours))]
        public virtual Theme? Theme { get; set; }

        [InverseProperty(nameof(CategorieVignoble.Sejours))]
        public virtual CategorieVignoble? CategorieVignoble { get; set; }

        [InverseProperty(nameof(Duree.Sejours))]
        public virtual Duree? Duree { get; set; }

        [InverseProperty(nameof(CategorieParticipant.Sejours))]
        public virtual CategorieParticipant? CategorieParticipant { get; set; }

        [InverseProperty(nameof(Localite.Sejours))]
        public virtual Localite? Localite { get; set; }

        
        [InverseProperty(nameof(Etape.Sejour))]
        public virtual ICollection<Etape> Etapes { get; set; } = new List<Etape>();

        [InverseProperty(nameof(Avis.Sejour))]
        public virtual ICollection<Avis> LesAvisSejour { get; set; } = new List<Avis>();

        [InverseProperty(nameof(Photo.Sejour))]
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();


    }
}