using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    public class ErrorController : Controller {

        [HttpGet("/Error")]
        public IActionResult Index() {
            return View("Error");
        }
    }
}
