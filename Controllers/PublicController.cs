using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CJ.Repository.Interfaces;

namespace CJ.Controllers
{
    public class PublicController : Controller
    {
        private readonly ILogger<PublicController> _logger;
        private readonly IGetData _getData;

        // Constructor to initialize the PublicController with required services.
        public PublicController(ILogger<PublicController> logger, IGetData getData)
        {
            _logger = logger;
            _getData = getData;
        }

        // Displays information about the company.
        [Authorize]
        public async Task<IActionResult> Om()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays contact details.
        [Authorize]
        public async Task<IActionResult> Kontakt()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays information about data policy (dont question why its called "Data usage").
        [Authorize]
        public async Task<IActionResult> Data_forbrug()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }
    }
}