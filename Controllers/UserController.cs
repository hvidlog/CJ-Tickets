using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var tickets = await _getData.GetTicketAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> Edit_ticket()
        {
            var tickets = await _getData.GetTicketAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> New_ticket()
        {
            var tickets = await _getData.GetTicketAsync();
            return View(tickets);
        }
    }
}