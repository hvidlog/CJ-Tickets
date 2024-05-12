using Microsoft.AspNetCore.Mvc;
using ZBC.Models;
//using ZBC.Models.TicketData;
using ZBC.ViewModels;

namespace ZBC.Repository.Interfaces
{
    public interface IGetData
    {
        Task<List<TicketOverviewViewModel>> GetTicketOverviewAsync();
        Task<List<TicketViewModel>> GetTicketAsync(int ticketid);
        Task<KatPrioStaViewModel> GetKatPrioStaAsync();
    }
}
