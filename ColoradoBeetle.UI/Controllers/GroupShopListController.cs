using ColoradoBeetle.Application.GroupShopLists.Command.AddGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopList;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    public class GroupShopListController : BaseController {
        public async Task<IActionResult> GroupShopLists(int id) {

            return View(await Mediator.Send(new GetGroupShopListsQuery {
                GroupId = id,
                UserId = UserId
            }));
        }

        public IActionResult AddGroupShopList(int id) {
            return View(new AddGroupShopListCommand { GroupId = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroupShopList(AddGroupShopListCommand command) {
           
            var result = await MediatorSendValidate(new AddGroupShopListCommand {
                Name = command.Name,
                GroupId = command.GroupId,
                UserId = UserId
            });

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Lista zakupów została dodana.";

            return RedirectToAction("GroupShopLists", "GroupShopList", 
                new { id = command.GroupId});
        }
    }
}
