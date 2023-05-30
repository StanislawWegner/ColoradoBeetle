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

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Contact() {
            return View();
        }


    }
}