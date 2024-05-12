using CJ.Models;
using CJ.ViewModels;

// Interfaces between controller and UpdateData.cs file - NOT IN USE

namespace CJ.Repository.Interfaces
{
    public interface IUpdateData
    {
        Task UpdateTicketAsync(Ticket ticket);
    }
}
