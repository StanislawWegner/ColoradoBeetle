using ColoradoBeetle.Application.GroupShopLists.Command.AddGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetEditGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    
    [Authorize]
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

        public async Task<IActionResult> EditGroupShopList(int id) {
            return View(await Mediator.Send(new GetEditGroupShopListQuery {
                Id = id,
                UserId = UserId
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroupShopList(EditGroupShopListCommand command) {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Lista została zaktualizowana.";

            return RedirectToAction("GroupShopLists", "GroupShopList",
                new { id = command.GroupId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroupShopList(int id) {
            try {
                Mediator.Send(new DeleteGroupShopListCommand {

                });
            }
        }
    }
}
