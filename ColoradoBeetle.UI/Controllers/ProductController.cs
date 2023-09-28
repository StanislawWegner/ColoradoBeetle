using ColoradoBeetle.Application.Products.Commands.AddProduct;
using ColoradoBeetle.Application.Products.Commands.CheckProduct;
using ColoradoBeetle.Application.Products.Commands.CheckStockProduct;
using ColoradoBeetle.Application.Products.Commands.CopyAllProducts;
using ColoradoBeetle.Application.Products.Commands.CopyOneProduct;
using ColoradoBeetle.Application.Products.Commands.DeleteProduct;
using ColoradoBeetle.Application.Products.Commands.EditProduct;
using ColoradoBeetle.Application.Products.Queries.GetAllProducts;
using ColoradoBeetle.Application.Products.Queries.GetChildProducts;
using ColoradoBeetle.Application.Products.Queries.GetEditProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers; 

[Authorize]
public class ProductController : BaseController{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }
    public async Task<IActionResult> GetProductsInList(int id) {
        
        return View(await Mediator.Send(
            new GetProductsInListQuery { ShoppingListId = id, UserId = UserId }));
    }



    public IActionResult AddProduct(int id) 
    {
        return View(new AddProductCommand
        {   ShoppingListId = id,
            UserId = UserId
        });
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(AddProductCommand command) {

        var result = await MediatorSendValidate(command);


        if (!result.IsValid)
            return View(command);

        TempData["Success"] = "Nowy produkt został dodany";

        return RedirectToAction("GetProductsInList", "Product",
            new { id = command.ShoppingListId });
    }

    public async Task<IActionResult> EditProduct(int id) {
        return View(await Mediator.Send(new GetEditProductQuery
        { Id = id,
          UserId = UserId
        }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProduct(EditProductCommand command) {

        var result = await MediatorSendValidate(command);

        if (!result.IsValid)
            return View(command);

        TempData["Success"] = "Product został zaktualizowany";

        return RedirectToAction("GetProductsInList", "Product", 
            new {id = command.ShoppingListId});
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id) {

        try {
            await Mediator.Send(new DeleteProductCommand
            { Id = id,
              UserId = UserId});


            return Json( new {success = true});
        }
        catch (Exception exception){
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }

    public async Task<IActionResult> CopyAllProducts(int id, int prntId) {

        try {
            await Mediator.Send(new CopyAllProductsCommand {
                ChildShoppingListId = id,
                ParentShoppingListId = prntId,
                UserId = UserId
            });

            TempData["Success"] = "Wszystkie produkty zostały skopiowane";

            return RedirectToAction("GetProductsInList", "Product", 
                new { id = prntId});
        }
        catch (Exception exception) {

            _logger.LogError(exception, null);
            TempData["Error"] = "Kopiowanie nieudane, " +
                "spróbuj ponownie lub skotaktuj się administratorem";
            return RedirectToAction("GetProductsInList", "Products",
                new { id });
        }
    }

    public async Task<IActionResult> GetChildProducts(int id, int prntId) {

        return View(await Mediator.Send(new GetChildProductsQuery {
            ChildShoppingListId = id,
            ParentShoppingListId = prntId,
            UserId = UserId
        }));
    }

    [HttpPost]
    public async Task<IActionResult> CopyOneProduct(int id, int prntId) {

        try {
            await Mediator.Send(new CopyOneProductCommand {
                Id = id,
                ParentShoppingListId = prntId,
                UserId = UserId
            });

            return Json(new {success = true});
        }
        catch (Exception exception) {
            _logger.LogError(exception, null);
            return Json(new {success = false});
        }
    }

    [HttpPost]
    public async Task<IActionResult> CheckProduct(int id, bool check) {

        try {
            await Mediator.Send(new CheckProductCommand { 
                Id = id,
                IsChecked = check,
                UserId = UserId
            });
            return Json(new { success = true });
        }
        catch (Exception exception){
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CheckStockProduct(int id, bool onStock) {

        try {
            await Mediator.Send(new CheckStockProductCommand {
                Id = id,
                OnStock = onStock,
                UserId = UserId
            });
            return Json(new { success = true });
        }
        catch (Exception exception){
            _logger.LogError(exception, null);
            return Json(new { success = false});
        }
    }
}