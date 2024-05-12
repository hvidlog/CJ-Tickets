using System.ComponentModel.DataAnnotations.Schema;
using CJ.Models;

namespace CJ.ViewModels
{
    public class TicketCreateViewModel
    {
        public string Titel { get; set; }
        public int KategoriId { get; set; }
        public string Beskrivelse { get; set; }
        public int PrioritetId { get; set; }
        public int BrugerId { get; set; }
        public int SupporterId { get; set; }
        //public IFormFile File { get; set; }
    }

}
