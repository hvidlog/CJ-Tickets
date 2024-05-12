//ViewModel to get Lists of ID's and names of the Kategory, Priority, and Status tables.
using CJ.Models;

namespace CJ.ViewModels
{
    public class KatPrioStaViewModel
    {
        public List<Kategorier>? Kategori { get; set; }
        public List<Prioriteter>? Prioritet { get; set; }
        public List<Status>? Status { get; set; }

        //public List<int> KategoriIDs { get; set; }
        //public List<string> KategoriNavne { get; set; }
        //public List<int> PrioritetIDs { get; set; }
        //public List<string> PrioritetNavne { get; set; }
        //public List<int> StatusIDs { get; set; }
        //public List<string> StatusNavne { get; set; }
    }
}
