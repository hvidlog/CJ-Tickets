using System.ComponentModel.DataAnnotations.Schema;
using CJ.Models;

namespace CJ.ViewModels
{
    public class TicketViewModel
    {
        public int TicketID { get; set; }
        public DateTime? Oprettelsestid { get; set; }
        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        //public string? BrugerFNavn { get; set; }
        //public string? BrugerLNavn { get; set; }
        //public string? BrugerEmail { get; set; }
        //public string? SupportFNavn { get; set; }
        //public string? SupportLNavn { get; set; }
        public string? StatusNavn { get; set; }
        public string? PrioritetNavn { get; set; }
        public DateTime? SidsteOpdatering { get; set; }
        public DateTime? LukkeTid { get; set; }
        public string? KategoriNavn { get; set; }
        public virtual Brugere Bruger { get; set; } = null!;
        public virtual Kategorier Kategori { get; set; } = null!;
        public virtual ICollection<Kommentarer> Kommentarers { get; set; } = new List<Kommentarer>();
        public virtual Prioriteter? PrioritetNavigation { get; set; }
        public virtual Status? Status { get; set; }
        public virtual Brugere? Supporter { get; set; }
        public KatPrioStaViewModel KatPrioStat { get; set; }
}
}
