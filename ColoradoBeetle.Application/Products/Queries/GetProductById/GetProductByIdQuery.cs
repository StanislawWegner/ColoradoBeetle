using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetProductById; 
public class GetProductByIdQuery : IRequest<ProductDto>{

    public int Id { get; set; }
}
