using APIVinotrip.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("se_localise")]
    public partial class SeLocalise
    {
        [Key]
        [Column("idroute")]
        public int IdRoute { get; set; }

        [Key]
        [Column("idcategorievignoble")]
        public int IdCategorieVignoble { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdRoute))]
        [InverseProperty(nameof(RouteDesVins.SesLocalites))]
        public virtual RouteDesVins? Route { get; set; }

        [ForeignKey(nameof(IdCategorieVignoble))]
        [InverseProperty(nameof(CategorieVignoble.SesLocalites))]
        public virtual CategorieVignoble? CategoriesVignoble { get; set; }
    }
}
