using Microsoft.AspNetCore.Mvc;
using CJ.Models;
//using CJ.Models.TicketData;
using CJ.ViewModels;

// Interfaces between controller and GetData.cs file

namespace CJ.Repository.Interfaces
{
    public interface IGetData
    {
        Task<List<TicketOverviewViewModel>> GetTicketOverviewAsync();
        Task<List<TicketViewModel>> GetTicketAsync(int ticketid);
        Task<KatPrioStaViewModel> GetKatPrioStaAsync();
    }
}
