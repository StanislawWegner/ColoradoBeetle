using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CopyOneProduct; 
public class CopyOneProductCommand : IRequest{
    public int Id { get; set; }
    public int ParentShoppingListId { get; set; }
    public string UserId { get; set; }
}
