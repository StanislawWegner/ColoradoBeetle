using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetProductById;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto> {
    public async Task<ProductDto> Handle(GetProductByIdQuery request, 
        CancellationToken cancellationToken) {

        return new ProductDto { Id = request.Id, Name = "Name"};
    }
}
