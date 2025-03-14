﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIVinotrip.Models.Entity_Framework
{
    [Table("AUTRESOCIETE")]
    public partial class AutreSociete
    {
        [Key]
        [Column("idPartenaire")]
        public int IdPartenaire { get; set; }

        [Column("nomPartenaire")]
        [StringLength(50)]
        public string? NomPartenaire { get; set; }

        [Column("mailPartenaire")]
        [StringLength(100)]
        public string? MailPartenaire { get; set; }

        [Column("telpartenaire")]
        [StringLength(10)]
        public string? Telpartenaire { get; set; }

        [ForeignKey(nameof(IdPartenaire))]
        [InverseProperty(nameof(Partenaire.AutreSocietePartenaire))]
        public virtual Partenaire? Partenaire { get; set; }


        [InverseProperty(nameof(EstProposePar.IdpartenaireNavigation))]
        public virtual ICollection<EstProposePar> EstProposePars { get; set; } = new List<EstProposePar>();
    }
}
