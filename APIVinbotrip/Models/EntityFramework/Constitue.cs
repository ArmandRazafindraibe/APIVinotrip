﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("constitue")]
    public partial class Constitue
    {
        [Key]
        [Column("idactivite")]
        public int IdActivite { get; set; }

        [Key]
        [Column("idetape")]
        public int IdEtape { get; set; }

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty(nameof(Activite.Constitues))]
        public virtual ICollection<Activite> Activites { get; set; } = new List<Activite>();

        [ForeignKey(nameof(IdEtape))]
        [InverseProperty(nameof(Etape.Constitues))]
        public virtual Etape SonEtape { get; set; } = null!;
    }
}
