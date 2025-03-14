using APIVinbotrip.Models.Entity_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using APIVinotrip.Models.Entity_Framework;

namespace APIVinbotrip.Models.Entity_Framework
{
	[Table("DESCRIPTIONPANIER")]
	public partial class DescriptionPanier
	{
		[Key]
		[Column("idDescriptionPanier")]
		public int IdDescriptionPanier { get; set; }

        [Column("idSejour")]
        public int? IdSejour { get; set; }

        [Column("idPanier")]
        public int? IdPanier { get; set; }

        [Column("idHebergement")]
        public int? IdHebergement { get; set; }

        [Column("quantite")]
		public int? Quantite { get; set; }

		[Column("dateDebut")]
		public DateTime? DateDebut { get; set; }

		[Column("dateFin")]
		public DateTime? DateFin { get; set; }

		[Column("nbAdultes")]
		public int? NbAdultes { get; set; }

		[Column("nbEnfants")]
		public int? NbEnfants { get; set; }

		[Column("nbChambresSimple")]
		public int? NbChambresSimple { get; set; }

		[Column("nbChambresDouble")]
		public int? NbChambresDouble { get; set; }

		[Column("nbChambresTriple")]
		public int? NbChambresTriple { get; set; }

		[Column("offrir")]
		public bool? Offrir { get; set; }

		[Column("eCoffret")]
		public bool? ECoffret { get; set; }

		[Column("disponibiliteHebergement")]
		public bool? DisponibiliteHebergement { get; set; }

	

        [ForeignKey(nameof(IdSejour))]
        [InverseProperty(nameof(Sejour.Descriptionpaniers))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey(nameof(IdPanier))]
        [InverseProperty(nameof(Panier.DescriptionsPanier))]
        public virtual Panier? Panier { get; set; }

        [ForeignKey(nameof(IdHebergement))]
        [InverseProperty(nameof(Hebergement.DescriptionsPanier))]
        public virtual Hebergement? Hebergement { get; set; }

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(Activite.Iddescriptionpaniers))]
        public virtual ICollection<Activite> Idactivites { get; set; } = new List<Activite>();

        [ForeignKey(nameof(IdDescriptionPanier))]
        [InverseProperty(nameof(Repas.Iddescriptionpaniers))]
        public virtual ICollection<Repas> Idrepas { get; set; } = new List<Repas>();
    }
}