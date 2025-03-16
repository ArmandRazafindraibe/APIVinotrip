﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace APIVinotrip.Models.EntityFramework
{
    [Table("LOCALITE")]
    public partial class Localite
    {
            [Key]
            [Column("idLocalite")]
            public int IdLocalite { get; set; }



            [Column("libelleLocalite")]
            [StringLength(50)]
            public string? LibelleLocalite { get; set; }

            [Column("idCategorieVignoble")]
            public int? IdCategorieVignoble { get; set; }

            [InverseProperty(nameof(Sejour.IdlocaliteNavigation))]
            public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();

            [ForeignKey(nameof(IdCategorieVignoble))]    
            [InverseProperty(nameof(CategorieVignoble.Localites))]
            public virtual CategorieVignoble? CategoriesVignoble { get; set; }
    }
}
