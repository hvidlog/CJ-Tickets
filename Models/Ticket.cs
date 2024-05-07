using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

public partial class Ticket
{
    [Key]
    [Column("TicketID")]
    public int TicketId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Oprettelsestid { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Titel { get; set; } = null!;

    [StringLength(1024)]
    [Unicode(false)]
    public string? Beskrivelse { get; set; }

    public short? Prioritet { get; set; }

    [Column("BrugerID")]
    public int BrugerId { get; set; }

    [Column("SupporterID")]
    public int? SupporterId { get; set; }

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column("PrioritetID")]
    public int? PrioritetId { get; set; }

    [Column("Sidste_Opdatering", TypeName = "datetime")]
    public DateTime? SidsteOpdatering { get; set; }

    [Column("Lukke_tid", TypeName = "datetime")]
    public DateTime? LukkeTid { get; set; }

    [Column("KategoriID")]
    public int KategoriId { get; set; }

    [ForeignKey("BrugerId")]
    [InverseProperty("TicketBrugers")]
    public virtual Brugere Bruger { get; set; } = null!;

    [ForeignKey("KategoriId")]
    [InverseProperty("Tickets")]
    public virtual Kategorier Kategori { get; set; } = null!;

    [InverseProperty("Ticket")]
    public virtual ICollection<Kommentarer> Kommentarers { get; set; } = new List<Kommentarer>();

    [ForeignKey("PrioritetId")]
    [InverseProperty("Tickets")]
    public virtual Prioriteter? PrioritetNavigation { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Tickets")]
    public virtual Status? Status { get; set; }

    [ForeignKey("SupporterId")]
    [InverseProperty("TicketSupporters")]
    public virtual Brugere? Supporter { get; set; }
}
