using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.AddProduct; 
public class AddProductCommand : IRequest{

    public string Name { get; set; }
}
