using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIVinotrip.Models.EntityFramework;

[Table("chatbot")]
public partial class Chatbot
{
    [Key]
    [Column("idchat")]
    public int Idchat { get; set; }

    [Column("messagechat")]
    [StringLength(500)]
    public string? Messagechat { get; set; }
}
