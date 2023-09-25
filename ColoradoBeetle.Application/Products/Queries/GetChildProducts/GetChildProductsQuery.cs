using ColoradoBeetle.Application.Products.Queries.GetProducts;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetChildProducts; 
public class GetChildProductsQuery : IRequest<GetChildProductsVm> {
    public int ChildShoppingListId { get; set; }
    public int ParentShoppingListId { get; set; }
    public string UserId { get; set; }
}
