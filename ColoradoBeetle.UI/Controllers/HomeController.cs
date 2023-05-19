using ColoradoBeetle.Application.Products.Commands.AddProduct;
using ColoradoBeetle.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ColoradoBeetle.UI.Controllers {
    public class HomeController : BaseController {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }
        public async Task<IActionResult> Index() {

            await Mediator.Send(new AddProductCommand { Name = "testiong coloradobeetle logging behaviour"});
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}