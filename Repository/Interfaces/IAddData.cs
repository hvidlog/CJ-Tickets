using Microsoft.AspNetCore.Mvc;
using CJ.Models;
//using CJ.Models.TicketData;
using CJ.ViewModels;

// Interfaces between controller and AddData.cs file

namespace CJ.Repository.Interfaces
{
    public interface IAddData
    {
        Task AddTicketAsync(TicketCreateViewModel model);
    }
}