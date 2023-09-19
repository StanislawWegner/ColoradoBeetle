using ColoradoBeetle.Application.Groups.Commands.AddGroup;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    public class GroupController : BaseController {
        public IActionResult AddGroup() {
            return View(new AddGroupCommand());
        }
    }
}
