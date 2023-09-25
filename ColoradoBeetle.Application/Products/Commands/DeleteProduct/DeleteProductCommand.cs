using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.DeleteProduct; 
public class DeleteProductCommand : IRequest{
    public int Id { get; set; }
    public string UserId { get; set; }
}
