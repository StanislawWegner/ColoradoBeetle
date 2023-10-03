using ColoradoBeetle.Application.GroupShopLists.Command.AddGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Command.DeleteGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetChildGroupShopLists;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetEditGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {
    
    [Authorize]
    public class GroupShopListController : BaseController {
        private readonly ILogger<GroupShopListController> _logger;

        public GroupShopListController(ILogger<GroupShopListController> logger)
        {
            _logger = logger;
        }
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
                await Mediator.Send(new DeleteGroupShopListCommand {
                    Id = id,
                    UserId = UserId
                });

                return Json(new { success = true });
            }
            catch (Exception exception){
                _logger.LogError(exception, null);
                return Json( new { success = false });
            }
        }

        public async Task<IActionResult> ChildGroupShopLists(int prntId, int groupId) {
            
            return View(await Mediator.Send(new GetChildGroupShopListsCommand {
                PrntId = prntId,
                GroupId = groupId,
                UserId = UserId
            }));
        }
    }
}
