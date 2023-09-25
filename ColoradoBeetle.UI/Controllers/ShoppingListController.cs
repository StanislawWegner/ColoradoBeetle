    using ColoradoBeetle.Application.ShoppingLists.Commands.AddShopinngList;
using ColoradoBeetle.Application.ShoppingLists.Commands.DeleteShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetEditShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingListForCopy;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers; 

[Authorize]
public class ShoppingListController : BaseController {
    private readonly ILogger<ShoppingListController> _logger;

    public ShoppingListController(ILogger<ShoppingListController> logger)
    {
        _logger = logger;
    }
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
        Name = command.Name, UserId = UserId});
            
        if (!result.IsValid) {
            return View(command);
        }

        TempData["Success"] = "List zakupów została dodana";

        return RedirectToAction("ShoppingLists");
    }

    public async Task<IActionResult> EditShoppingList(int id) {

        return View(await Mediator.Send(
            new GetEditShoppingListQuery { Id = id, UserId = UserId }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditShoppingList(EditShoppingListCommand command) {

        var result = await MediatorSendValidate(command);

        if(!result.IsValid)
            return View(command);

        TempData["Success"] = "Nazwa listy została zaktualizowana";

        return RedirectToAction("ShoppingLists");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteShoppingList(int id) {

        try {
            await Mediator.Send(new DeleteShoppingListCommand
            {
                Id = id,
                UserId = UserId
            });

            return Json( new { success = true });
        }
        catch (Exception exception){
            _logger.LogError(exception, null);

            return Json(new {success = false});
        }
    }

    public async Task<IActionResult> ChildShoppingLists(int id) {

        return View(await Mediator.Send(new GetChildShoppingListsQuery 
        { UserId = UserId,
          ParentShoppingListId = id
        }));
    }

    



}


