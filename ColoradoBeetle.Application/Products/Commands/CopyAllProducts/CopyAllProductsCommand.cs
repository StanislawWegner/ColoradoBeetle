using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CopyAllProducts; 
public class CopyAllProductsCommand : IRequest{
    public int ParentShoppingListId { get; set; }
    public int ChildShoppingListId { get; set; }
}
