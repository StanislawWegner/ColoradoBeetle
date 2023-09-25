using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Commands.EditProduct;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetEditProduct;
public class GetEditProductQueryHandler : IRequestHandler<GetEditProductQuery,
    EditProductCommand> {
    private readonly IProductService _productService;

    public GetEditProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<EditProductCommand> Handle(GetEditProductQuery request,
        CancellationToken cancellationToken) {

        var productDb = await _productService.FindByIdAsync(request.Id, request.UserId);

        return new EditProductCommand { 
            Id = productDb.Id,
            Name = productDb.Name,
            Quantity = productDb.Quantity,
            Volume = productDb.Volume,
            VolumeUnit = productDb.VolumeUnit,
            ShoppingListId = productDb.ShoppingListId,
            UserId = request.UserId,
        };
    }
}
