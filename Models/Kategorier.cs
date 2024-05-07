using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZBC.Models;

[Table("Kategorier")]
public partial class Kategorier
{
    [Key]
    [Column("KategoriID")]
    public int KategoriId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string Navn { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string? Beskrivelse { get; set; }

    [InverseProperty("Kategori")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
