using ZBC.Models;

namespace ZBC.Repository.Interfaces
{
    public interface IUpdateData
    {
        Task UpdateTicketAsync(Ticket ticket);
    }
}
