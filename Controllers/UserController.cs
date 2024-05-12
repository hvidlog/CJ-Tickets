using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using CJ.Models;
using CJ.Repository.Interfaces;
using CJ.ViewModels;

namespace CJ.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IGetData _getData;
        private readonly IAddData _addDataService;
        private readonly IUpdateData _updateDataService;

        // Constructor to initialize the UserController with required services.
        public UserController(ILogger<UserController> logger, IGetData getData, IAddData addDataService, IUpdateData updateDataService)
        {
            _logger = logger;
            _getData = getData;
            _addDataService = addDataService;
            _updateDataService = updateDataService;
        }

        // Displays the list of tickets.
        [Authorize]
        public async Task<IActionResult> index()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        // Displays the form to edit a specific ticket.
        [Authorize]
        public async Task<IActionResult> Edit_ticket(int ticket)
        {
            var tickets = await _getData.GetTicketAsync(ticket);
            return View(tickets);
        }

        // Displays the form to update a ticket - NOT IN USE
        [Authorize]
        public IActionResult Update()
        {
            return View("edit_ticket", new Ticket());
        }

        // Handles the POST request to edit a ticket - NOT IN USE
        [HttpPost]
        public async Task<IActionResult> Edit_ticket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                // Log or examine the model state errors.
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return View();
            }

            await _updateDataService.UpdateTicketAsync(ticket);

            return RedirectToAction("index");
        }

        // Displays the form to create a new ticket.
        [Authorize]
        public async Task<IActionResult> New_ticket()
        {
            return View();
        }

        // Displays the form to create a new ticket.
        [Authorize]
        public IActionResult Create()
        {
            return View("new_ticket", new TicketCreateViewModel());
        }

        // Handles the POST request to create a new ticket.
        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Log or examine the model state errors.
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError(error.ErrorMessage);
                }
                return View("new_ticket", model);
            }

            await _addDataService.AddTicketAsync(model);

            return RedirectToAction("index");
        }
    }
}
