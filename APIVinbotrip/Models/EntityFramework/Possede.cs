namespace APIVinotrip.Models.EntityFramework
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace APIVinotrip.Models.EntityFramework
    {
        [Table("possede")]
        public partial class Possede
        {
            [Key]
            [Column("idactivite")]
            public int IdActivite { get; set; }

            [Key]
            [Column("iddescriptioncommande")]
            public int IdDescriptionCommande { get; set; }

            [ForeignKey(nameof(IdActivite))]
            [InverseProperty(nameof(Activite.LesPossedes))]
            public virtual Activite LActivite { get; set; } = null!;

            [ForeignKey(nameof(IdDescriptionCommande))]
            [InverseProperty(nameof(DescriptionCommande.LesPossedes))]
            public virtual DescriptionCommande LaDescriptionCommande { get; set; } = null!;
        }
    }
}
