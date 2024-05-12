using Microsoft.AspNetCore.Mvc;
using CJ.Models;
//using CJ.Models.TicketData;
using CJ.ViewModels;

namespace CJ.Repository.Interfaces
{
    public interface IGetData
    {
        Task<List<TicketOverviewViewModel>> GetTicketOverviewAsync();
        Task<List<TicketViewModel>> GetTicketAsync(int ticketid);
        Task<KatPrioStaViewModel> GetKatPrioStaAsync();
    }
}
