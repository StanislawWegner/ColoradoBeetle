using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class ShoppingList : BaseController {
        public async Task<IActionResult> ShoppingLists() {

            return View(await Mediator.Send(new GetShoppingListsQuery {UserId = UserId }));
        }
    }
}
