using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CJ.Models;
using CJ.Repository;
using CJ.Repository.Interfaces;

namespace CJ.Controllers
{
    public class SupportController : Controller
    {
        private readonly ILogger<SupportController> _logger;
        private readonly IGetData _getData;

        // Constructor to initialize the SupportController with required services.
        public SupportController(ILogger<SupportController> logger, IGetData getData)
        {
            _logger = logger;
            _getData = getData;
        }

        // Displays the home page for support, showing ticket overview.
        [Authorize]
        public async Task<IActionResult> Home()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays the support dashboard, showing ticket overview.
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays the admin panel for support, showing ticket overview.
        [Authorize]
        public async Task<IActionResult> Admin()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays the page to change a ticket.
        [Authorize]
        public async Task<IActionResult> Ticket_change()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Handles errors and displays error view.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}