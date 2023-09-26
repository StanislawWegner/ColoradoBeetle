using ColoradoBeetle.Application.UserGroups.Queries.GetGroupMembers;
using ColoradoBeetle.Application.UserGroups.Queries.GetUserGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class UserGroupsController : BaseController {

        public async Task<IActionResult> UserGroups() {
            return View(await Mediator.Send(new GetUserGroupQuery { UserId = UserId }));
        }

        public async Task<IActionResult> GroupMembers(int id) {
            return View(await Mediator.Send(new GetGroupMembersQuery 
            { 
                GroupId = id,
                UserId = UserId 
            }));
        }
    }
}
