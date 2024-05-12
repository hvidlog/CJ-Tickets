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

        public UserController(ILogger<UserController> logger, IGetData getData, IAddData addDataService)
        {
            _logger = logger;
            _getData = getData;
            _addDataService = addDataService;

        }

        [Authorize]
        public async Task<IActionResult> index()
        {
            var tickets = await _getData.GetTicketOverviewAsync();
            return View(tickets);
        }

        [Authorize]
        public async Task<IActionResult> Edit_ticket(int ticket)
        {
            
            var tickets = await _getData.GetTicketAsync(ticket);
            return View(tickets);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit_ticket(Ticket ticket)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Log or examine the model state
        //        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //        {
        //            _logger.LogError(error.ErrorMessage);
        //        }
        //        return View();
        //    }

        //    await _addDataService.UpdateTicketAsync(ticket);

        //    return RedirectToAction("index");
        //}



        [Authorize]
        public async Task<IActionResult> New_ticket()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View("new_ticket", new TicketCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Log or examine the model state
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