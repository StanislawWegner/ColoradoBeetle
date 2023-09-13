using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists; 
public class GetShoppingListsQueryHandler : IRequestHandler<GetShoppingListsQuery,
    IEnumerable<ShoppingListDto>> {
    private readonly IShoppingListService _shoppingListService;

    public GetShoppingListsQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }

    public async Task<IEnumerable<ShoppingListDto>> Handle(GetShoppingListsQuery request
        , CancellationToken cancellationToken) {

         return _shoppingListService.GetShoppingListsDtos(request.UserId);
    }
}
