using APIVinbotrip.Models.Entity_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("SE_LOCALISE")]
    public partial class SELocalise
    {
        [Key]
        [Column("idRoute")]
        public int IdRoute { get; set; }

        [Key]
        [Column("idCategorieVignoble")]
        public int IdCategorieVignoble { get; set; }

        // Navigation properties
        [ForeignKey("IdRoute")]
        [InverseProperty(nameof(RouteDesVins.SaLocalites))]
        public virtual RouteDesVins? Route { get; set; }

        [ForeignKey("IdCategorieVignoble")]
        [InverseProperty(nameof(CategorieVignoble.SaLocalites))]
        public virtual CategorieVignoble? CategorieVignoble { get; set; }
    }
}
