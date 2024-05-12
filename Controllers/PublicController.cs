using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CJ.Repository.Interfaces;

namespace CJ.Controllers
{
    public class PublicController : Controller
    {
        private readonly ILogger<PublicController> _logger;
        private readonly IGetData _getData;

        public PublicController(ILogger<PublicController> logger, IGetData getData)
        {
            _logger = logger;
            _getData = getData;
        }

        [Authorize]
        public async Task<IActionResult> Om()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> Kontakt()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> Data_forbrug()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }
    }
}