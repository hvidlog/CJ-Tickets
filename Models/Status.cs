using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CJ.Models;

[Table("Status")]
public partial class Status
{
    [Key]
    [Column("StatusID")]
    public int StatusId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string Navn { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string? Beskrivelse { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
