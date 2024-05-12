using CJ.Models;

namespace CJ.Repository.Interfaces
{
    public interface IUpdateData
    {
        Task UpdateTicketAsync(Ticket ticket);
    }
}
