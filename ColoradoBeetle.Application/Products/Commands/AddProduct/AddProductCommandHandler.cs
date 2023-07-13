using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.AddProduct;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand> {
    private readonly IProductService _productService;

    public AddProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<Unit> Handle(AddProductCommand request, 
        CancellationToken cancellationToken) {

        await _productService.CreateAsync(request);

        return Unit.Value;
    }

}
