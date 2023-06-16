using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    public class ClientController : BaseController {
        public IActionResult Dashboard() {
            return View();
        }

        public IActionResult Client() {
            return View();
        }
    }
}
