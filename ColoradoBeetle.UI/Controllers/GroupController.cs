using ColoradoBeetle.Application.Dictionaries;
using ColoradoBeetle.Application.Groups.Commands.AddGroup;
using ColoradoBeetle.Application.Groups.Commands.AddUserToGroup;
using ColoradoBeetle.Application.Groups.Commands.DeleteGroup;
using ColoradoBeetle.Application.Groups.Commands.EditGroup;
using ColoradoBeetle.Application.Groups.Commands.RemoveUserFromGroup;
using ColoradoBeetle.Application.Groups.Queries.GetEditGroup;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUserGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUsersDtos;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using ColoradoBeetle.Application.Products.Commands.CopyAllProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize(Roles = RolesDict.Administrator)]
    public class GroupController : BaseController {
        private readonly ILogger<GroupController> _logger;


        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Groups() {

            return View(await Mediator.Send(new GetGroupsQuery()));
        }
        
        public IActionResult AddGroup() {
            return View(new AddGroupCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroup(AddGroupCommand command) {

            var result = await MediatorSendValidate(command);

            if(!result.IsValid)
                return View(command);

            TempData["Success"] = "Nowa grupa została utworzona.";

            return RedirectToAction("Groups");
        }


        public async Task<IActionResult> EditGroup(int id) {
            return View(await Mediator.Send(new GetEditGroupQuery { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroup(EditGroupCommand command) {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Nazwa grupy została zmieniona";

            return RedirectToAction("Groups");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(int id) {
            try {
                await Mediator.Send(new DeleteGroupCommand { Id = id });
                return Json(new { success = true });
            }
            catch (Exception exception){
                _logger.LogError(exception, null);
                return Json( new { success = false });
            }
        }

        public async Task<IActionResult> UsersInGroup(int id) {

            return View(await Mediator.Send(new GetUsersInGroupQuery { Id = id}));
        }

        public async Task<IActionResult> GetUsersDtos(int groupId) {

            return View(await Mediator.Send(new GetUserDtosQuery {
                GroupId = groupId
            }));
        }

        public async Task<IActionResult> AddUserToGroup(string id, int groupId ) {
           
            try {
                await Mediator.Send(new AddUserToGroupCommand {
                    GroupId = groupId,
                    UserId = id
                });

                TempData["Success"] = "Użytkownik został dodany do grupy";

                return RedirectToAction("UsersInGroup", "Group",
                    new { id = groupId });
            }
            catch (Exception exception) {

                _logger.LogError(exception, null);
                TempData["Error"] = "Dodawanie nieudane.";
                return RedirectToAction("UsersInGroup", "Group",
                    new { id = groupId});
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(string id, int groupId) {

            try {
                await Mediator.Send(new RemoveUserFromGroupCommand {
                    UserId = id,
                    GroupId = groupId
                });

                return Json( new { success = true });
            }
            catch (Exception exception){
                _logger.LogError(exception, null);
                return Json( new {success = false });
            }
        }
        public async Task<IActionResult> UserGroups() {
            return View(await Mediator.Send(new GetUserGroupQuery { UserId = UserId }));
        }

    }
}
