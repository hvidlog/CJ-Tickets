using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

[Table("Roller")]
public partial class Roller
{
    [Key]
    [Column("RolleID")]
    public int RolleId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? Navn { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? Beskrivelse { get; set; }

    [Column("BrugerAdm_Full")]
    public bool? BrugerAdmFull { get; set; }

    [Column("BrugerAdm_RO")]
    public bool? BrugerAdmRo { get; set; }

    [Column("Ticket_Full")]
    public bool? TicketFull { get; set; }

    [Column("Ticket_RO")]
    public bool? TicketRo { get; set; }

    [Column("Ticket_Bruger")]
    public bool? TicketBruger { get; set; }

    [Column("Database_Full")]
    public bool? DatabaseFull { get; set; }

    [Column("Database_RO")]
    public bool? DatabaseRo { get; set; }

    [InverseProperty("Rolle")]
    public virtual ICollection<Brugere> Brugeres { get; set; } = new List<Brugere>();
}
