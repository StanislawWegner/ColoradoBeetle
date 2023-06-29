using ColoradoBeetle.Application.ShoppingLists.Commands.AddShopinngList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Infrastructure.Persistence.Migrations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class ShoppingListController : BaseController {
        public async Task<IActionResult> ShoppingLists() {

            return View(await Mediator.Send(new GetShoppingListsQuery {UserId = UserId }));
        }

        public IActionResult AddShoppingList() {

            return View(new AddShoppingListCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShoppingList(AddShoppingListCommand command) {

            var result = await MediatorSendValidate(new AddShoppingListCommand {
                Name = command.Name,
                UserId = UserId
            });

            if (!result.IsValid) {
                return View(command);
            }

            TempData["Success"] = "List zakupów została dodana";

            return RedirectToAction("ShoppingLists");
        }

        



    }

   
}
