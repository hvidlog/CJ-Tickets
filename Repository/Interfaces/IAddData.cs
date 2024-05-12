using Microsoft.AspNetCore.Mvc;
using CJ.Models;
//using CJ.Models.TicketData;
using CJ.ViewModels;

namespace CJ.Repository.Interfaces
{
    public interface IAddData
    {
        Task AddTicketAsync(TicketCreateViewModel model);
    }
}
