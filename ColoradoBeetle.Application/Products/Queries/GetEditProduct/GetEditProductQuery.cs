using ColoradoBeetle.Application.Products.Commands.EditProduct;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetEditProduct; 
public class GetEditProductQuery : IRequest<EditProductCommand>{
    public int Id { get; set; }
    public int ShoppingListId { get; set; }
    public string UserId { get; set; }
}
