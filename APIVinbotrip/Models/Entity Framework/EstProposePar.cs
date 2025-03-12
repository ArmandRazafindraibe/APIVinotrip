using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace  APIVinotrip.Models.Entity_Framework;

[PrimaryKey("Idpartenaire", "Idactivite", "Idadresse")]
public partial class EstProposePar
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

    [ForeignKey(nameof(Idactivite))]
    [InverseProperty(nameof(Activite.IdActivite))]
    public virtual Activite IdactiviteNavigation { get; set; } = null!;

    [ForeignKey(nameof(Idadresse))]
    [InverseProperty("EstProposePars")]
    public virtual Adresse IdadresseNavigation { get; set; } = null!;

    [ForeignKey(nameof(Idpartenaire))]
    [InverseProperty("EstProposePars")]
    public virtual AutreSociete IdpartenaireNavigation { get; set; } = null!;
}
