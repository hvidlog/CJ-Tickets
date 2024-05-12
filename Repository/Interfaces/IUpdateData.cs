using CJ.Models;
using CJ.ViewModels;

namespace CJ.Repository.Interfaces
{
    public interface IUpdateData
    {
        Task UpdateTicketAsync(Ticket ticket);
    }
}
