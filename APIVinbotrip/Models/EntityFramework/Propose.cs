using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.EntityFramework;

[PrimaryKey("Idpartenaire", "Idactivite", "Idadresse")]
public partial class Propose
{
    [Key]
    [Column("idpartenaire")]
    public int Idpartenaire { get; set; }

    [Key]
    [Column("idactivite")]
    public int Idactivite { get; set; }

    [Key]
    [Column("idadresse")]
    public int Idadresse { get; set; }

    [ForeignKey("Idactivite")]
    [InverseProperty("Propose4s")]
    public virtual Activite IdactiviteNavigation { get; set; } = null!;

    [ForeignKey("Idadresse")]
    [InverseProperty("Propose4s")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [ForeignKey("Idpartenaire")]
    [InverseProperty("Propose4s")]
    public virtual Autresociete IdpartenaireNavigation { get; set; } = null!;
}