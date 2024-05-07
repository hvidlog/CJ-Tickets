using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

[Table("Vedhæftninger")]
public partial class Vedhæftninger
{
    [Key]
    [Column("VedhæftningID")]
    public int VedhæftningId { get; set; }

    [Column("KommentarID")]
    public int? KommentarId { get; set; }

    public byte[]? Vedhæftning { get; set; }

    [ForeignKey("KommentarId")]
    [InverseProperty("Vedhæftningers")]
    public virtual Kommentarer? Kommentar { get; set; }
}
