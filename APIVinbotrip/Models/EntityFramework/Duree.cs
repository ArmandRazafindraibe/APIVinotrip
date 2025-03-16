﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace APIVinotrip.Models.EntityFramework
{
    [Table("DUREE")]
    public partial class Duree
    {
        [Key]
        [Column("idDuree")]
        public int IdDuree { get; set; }

        [Column("libelleDuree")]
        [StringLength(50)]
        public string? LibelleDuree { get; set; }

        [InverseProperty(nameof(Sejour.IddureeNavigation))]
        public virtual ICollection<Sejour> Sejours { get; set; } = new List<Sejour>();
    }

}
