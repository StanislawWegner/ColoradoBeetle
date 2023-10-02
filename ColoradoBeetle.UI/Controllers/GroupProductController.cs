using ColoradoBeetle.Application.GroupProducts.Commands.AddGroupProduct;
using ColoradoBeetle.Application.GroupProducts.Commands.DeleteGroupProduct;
using ColoradoBeetle.Application.GroupProducts.Commands.EditGroupProduct;
using ColoradoBeetle.Application.GroupProducts.Queries.GetEditGroupProduct;
using ColoradoBeetle.Application.GroupProducts.Queries.GetGroupProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ColoradoBeetle.UI.Controllers {

    [Authorize]
    public class GroupProductController : BaseController {
        private readonly ILogger<GroupProductController> _logger;

        public GroupProductController(ILogger<GroupProductController> logger)
        {
            _logger = logger;
        }
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

        public async Task<IActionResult> EditGroupProduct(int id, int groupId) {
            return View(await Mediator.Send(new GetEditGroupProductQuery {
                Id = id,
                GroupId = groupId,
                UserId = UserId
            }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGroupProduct(EditGroupProductCommand command) {

            var result  = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Produkt został zaktualizowany";

            return RedirectToAction("GroupProducts", "GroupProduct",
                new { id = command.GroupShopListId, groupId = command.GroupId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroupProduct(int id) {

            try {
                await Mediator.Send(new DeleteGroupProductCommand {
                    Id = id,
                    UserId = UserId,
                });

                return Json( new { success = true });
            }
            catch (Exception exception){
                _logger.LogError(exception, null);

                return Json( new { success = false });
            }
        }
    }
}
