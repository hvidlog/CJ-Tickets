using Microsoft.AspNetCore.Mvc;
using ZBC.Models;
//using ZBC.Models.TicketData;
using ZBC.ViewModels;

namespace ZBC.Repository.Interfaces
{
    public interface IAddData
    {
        Task AddTicketAsync(TicketCreateViewModel model);
    }
}
