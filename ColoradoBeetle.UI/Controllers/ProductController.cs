using ColoradoBeetle.Application.Products.Commands.AddProduct;
using ColoradoBeetle.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Controllers; 

[Authorize]
public class ProductController : BaseController{


    public IActionResult AddProduct(int id) 
    {

        return View(new AddProductCommand { ShoppingListId = id});
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(AddProductCommand command) {

        var result = await MediatorSendValidate(command);


        if (!result.IsValid)
            return View(command);

        TempData["Success"] = "Nowy produkt został dodany";

        return View(command);
    }




}