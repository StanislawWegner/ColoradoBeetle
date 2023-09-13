using ColoradoBeetle.Application.Products.Queries.GetProducts;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetAllProducts;
public class GetProductsInListQuery : IRequest<GetProductsInListVm>{
    public int ShoppingListId { get; set; }
}
