using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

[Table("Brugere")]
public partial class Brugere
{
    [Key]
    [Column("BrugerID")]
    public int BrugerId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string Brugernavn { get; set; } = null!;

    public int? Tlf { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string Passhash { get; set; } = null!;

    [Column("RolleID")]
    public int RolleId { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Fornavn { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Efternavn { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Afdeling { get; set; } = null!;

    [InverseProperty("ForfatterNavigation")]
    public virtual ICollection<Kommentarer> Kommentarers { get; set; } = new List<Kommentarer>();

    [ForeignKey("RolleId")]
    [InverseProperty("Brugeres")]
    public virtual Roller Rolle { get; set; } = null!;

    [InverseProperty("Bruger")]
    public virtual ICollection<Ticket> TicketBrugers { get; set; } = new List<Ticket>();

    [InverseProperty("Supporter")]
    public virtual ICollection<Ticket> TicketSupporters { get; set; } = new List<Ticket>();
}
