using ColoradoBeetle.Application.GroupProducts.Commands.AddGroupProduct;
using ColoradoBeetle.Application.GroupProducts.Queries.GetGroupProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class GroupProductController : BaseController {
        public async Task<IActionResult> GroupProducts(int id, int groupId) {
            return View(await Mediator.Send(new GetGroupProductsQuery
            {
                GroupShopListId = id,
                GroupId = groupId,
                UserId = UserId
            }));
        }

        public IActionResult AddGroupProduct(int shopListId, int groupId) {
            return View(new AddGroupProductCommand {
                GroupShopListId = shopListId,
                GroupId = groupId,
                UserId = UserId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroupProduct(AddGroupProductCommand command) {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Produkt został dodany";

            return RedirectToAction("GroupProducts", "GroupProduct",
                new { id = command.GroupShopListId, groupId = command.GroupId });
        }
    }
}
