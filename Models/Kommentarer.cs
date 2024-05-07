using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

[Table("Kommentarer")]
public partial class Kommentarer
{
    [Key]
    [Column("KommentarID")]
    public int KommentarId { get; set; }

    [Column("TicketID")]
    public int? TicketId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Tid { get; set; }

    [StringLength(1024)]
    [Unicode(false)]
    public string? Beskeden { get; set; }

    public bool? BrugerSynlighed { get; set; }

    public int? Forfatter { get; set; }

    [ForeignKey("Forfatter")]
    [InverseProperty("Kommentarers")]
    public virtual Brugere? ForfatterNavigation { get; set; }

    [ForeignKey("TicketId")]
    [InverseProperty("Kommentarers")]
    public virtual Ticket? Ticket { get; set; }

    [InverseProperty("Kommentar")]
    public virtual ICollection<Vedhæftninger> Vedhæftningers { get; set; } = new List<Vedhæftninger>();
}
