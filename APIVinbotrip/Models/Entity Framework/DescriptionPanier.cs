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

		[InverseProperty(nameof(Detient.IdDescriptionPanier))]
		public virtual ICollection<Detient> ListeRepas { get; set; } = new List<Detient>();

		[InverseProperty(nameof(Comporte.DescriptionPanierComporte))]
		public virtual ICollection<Comporte> ListeDescriptions { get; set; } = new List<Comporte>();

        [ForeignKey("IdSejour")]
        [InverseProperty(nameof(Sejour.DescriptionsPanier))]
        public virtual Sejour? Sejour { get; set; }

        [ForeignKey("IdPanier")]
        [InverseProperty(nameof(Panier.DescriptionsPanier))]
        public virtual Panier? Panier { get; set; }

        [ForeignKey("IdHebergement")]
        [InverseProperty(nameof(Hebergement.DescriptionsPanier))]
        public virtual Hebergement? Hebergement { get; set; }
    }
}