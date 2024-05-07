using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZBC.Models;
using ZBC.Repository;
using ZBC.Repository.Interfaces;

namespace ZBC.Controllers
{
    public class SupportController : Controller
    {
        private readonly ILogger<SupportController> _logger;
        private readonly IGetData _getData;

        public SupportController(ILogger<SupportController> logger, IGetData getData)
        {
            _logger = logger;
            _getData = getData;
        }

        [Authorize]
        public async Task<IActionResult> S_home()
        {
            var tickets = await _getData.GetTicketAsync();
            return View(tickets);
        }

        //[Authorize]
        //public async Task<IActionResult> Test()
        //{
        //    var productCatalog = await _getData.GetTicketAsync();
        //    return View(productCatalog);
        //}
        //public async Task<IActionResult> om()
        //{
        //    var productCatalog = await _getData.GetProductCatalogAsync();
        //    return View(productCatalog);
        //}

        //public async Task<IActionResult> Kontakt()
        //{
        //    var productCatalog = await _getData.GetProductCatalogAsync();
        //    return View(productCatalog);
        //}

        //public async Task<IActionResult> Data_forbrug()
        //{
        //    var productCatalog = await _getData.GetProductCatalogAsync();
        //    return View(productCatalog);
        //}

        //[Authorize]
        //public async Task<IActionResult> new_ticket()
        //{
        //    var productCatalog = await _getData.GetProductCatalogAsync();
        //    return View(productCatalog);
        //}

        //[Authorize]
        //public async Task<IActionResult> edit_ticket()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public async Task<IActionResult> S_home()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public async Task<IActionResult> S_ny_edit_tickets()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public async Task<IActionResult> S_admin()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public async Task<IActionResult> S_dashboard()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public async Task<IActionResult> Dashboard()
        //{
        //    var productCatalogByMaker = await _getData.GetProductCatalogByMakerAsync();
        //    return View(productCatalogByMaker);
        //}

        //[Authorize]
        //public IActionResult Playground()
        //{
        //    var products = _getData.GetAllProductsAsync().Result; 
        //    if (products == null)
        //    {
        //        products = new List<Product>();
        //    }

        //    return View(products);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
