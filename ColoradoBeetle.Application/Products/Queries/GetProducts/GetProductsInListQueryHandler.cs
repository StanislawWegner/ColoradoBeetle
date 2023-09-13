using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Application.ShoppingLists.Extensions;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetAllProducts;
public class GetProductsInListQueryHandler : IRequestHandler<GetProductsInListQuery,
    GetProductsInListVm> {
    private readonly IProductService _productService;
    private readonly IShoppingListService _shoppingListService;

    public GetProductsInListQueryHandler(IProductService productService,
        IShoppingListService shoppingListService)
    {
        _productService = productService;
        _shoppingListService = shoppingListService;
    }

    public async Task<GetProductsInListVm> Handle(GetProductsInListQuery request, 
        CancellationToken cancellationToken) {

        var productsInList = _productService.GetProductsInListDtos(request.ShoppingListId);

        var shoppingListDto = (await _shoppingListService
            .FindByIdAsync(request.ShoppingListId))
            .ToDto();

        return new GetProductsInListVm {
            ProductDtoList = productsInList,
            ShoppingListDto = shoppingListDto
        };
    }
}
