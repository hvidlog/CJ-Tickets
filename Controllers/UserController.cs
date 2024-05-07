using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using ZBC.Models;
using ZBC.Repository.Interfaces;

namespace ZBC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IGetData _getData;

        public UserController(ILogger<UserController> logger, IGetData getData)
        {
            _logger = logger;
            _getData = getData;
        }

        [Authorize]
        public async Task<IActionResult> index()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> Edit_ticket(int ticket )
        {
            
            var tickets = await _getData.GetTicketAsync(ticket);
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> New_ticket()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }
    }
}