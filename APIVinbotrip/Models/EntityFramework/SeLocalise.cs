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
        [Column("idRoute")]
        public int IdRoute { get; set; }

        [Key]
        [Column("idcategorievignoble")]
        public int IdCategorieVignoble { get; set; }

        // Navigation properties
        [ForeignKey(nameof(IdRoute))]
        [InverseProperty(nameof(RouteDesVins.SesLocalites))]
        public virtual ICollection<RouteDesVins>? Route { get; set; } = new List<RouteDesVins>();

        [ForeignKey(nameof(IdCategorieVignoble))]
        [InverseProperty(nameof(CategorieVignoble.SesLocalites))]
        public virtual ICollection<CategorieVignoble> CategoriesVignoble { get; set; }=new List<CategorieVignoble>();
    }
}
