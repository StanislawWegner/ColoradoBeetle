using ColoradoBeetle.Application.Dictionaries;
using ColoradoBeetle.Application.Groups.Commands.AddGroup;
using ColoradoBeetle.Application.Groups.Commands.DeleteGroup;
using ColoradoBeetle.Application.Groups.Commands.EditGroup;
using ColoradoBeetle.Application.Groups.Queries.GetEditGroup;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUserGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class GroupController : BaseController {
        private readonly ILogger<GroupController> _logger;


        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = RolesDict.Administrator)]
        public async Task<IActionResult> Groups() {

            return View(await Mediator.Send(new GetGroupsQuery()));
        }
        
        [Authorize(Roles = RolesDict.Administrator)]
        public IActionResult AddGroup() {
            return View(new AddGroupCommand());
        }

        [Authorize(Roles = RolesDict.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroup(AddGroupCommand command) {

            var result = await MediatorSendValidate(command);

            if(!result.IsValid)
                return View(command);

            TempData["Success"] = "Nowa grupa została utworzona.";

            return RedirectToAction("Groups");
        }


        [Authorize(Roles = RolesDict.Administrator)]
        public async Task<IActionResult> EditGroup(int id) {
            return View(await Mediator.Send(new GetEditGroupQuery { Id = id }));
        }

        [Authorize(Roles = RolesDict.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroup(EditGroupCommand command) {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Nazwa grupy została zmieniona";

            return RedirectToAction("Groups");
        }

        [Authorize(Roles = RolesDict.Administrator)]
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

        [Authorize(Roles = RolesDict.Administrator)]
        public async Task<IActionResult> UsersInGroup(int id) {

            return View(await Mediator.Send(new GetUsersInGroupQuery { Id = id}));
        }

        public async Task<IActionResult> UserGroups() {
            return View(await Mediator.Send(new GetUserGroupQuery { UserId = UserId }));
        }

    }
}
