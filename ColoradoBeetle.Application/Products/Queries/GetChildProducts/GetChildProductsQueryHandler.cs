using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Application.ShoppingLists.Extensions;
using MediatR;

namespace ColoradoBeetle.Application.Products.Queries.GetChildProducts;
public class GetChildProductsQueryHandler : IRequestHandler<GetChildProductsQuery
    , GetChildProductsVm> {
    private readonly IProductService _productService;
    private readonly IShoppingListService _shoppingListService;

    public GetChildProductsQueryHandler(IProductService productService,
        IShoppingListService shoppingListService)
    {
        _productService = productService;
        _shoppingListService = shoppingListService;
    }
    public async Task<GetChildProductsVm> Handle(GetChildProductsQuery request, 
        CancellationToken cancellationToken) {

        var products = _productService.GetProductsInListDtos(request.ChildShoppingListId);

        var childShoppingListDto = (await _shoppingListService
            .FindByIdAsync(request.ChildShoppingListId)).ToDto();

        var parentShoppingListDto = (await _shoppingListService
            .FindByIdAsync(request.ParentShoppingListId)).ToDto();


        return new GetChildProductsVm {
            ProductDtoList = products,
            ParentShoppingListDto = parentShoppingListDto,
            ChildShoppingListDto = childShoppingListDto
        };
    }
}
