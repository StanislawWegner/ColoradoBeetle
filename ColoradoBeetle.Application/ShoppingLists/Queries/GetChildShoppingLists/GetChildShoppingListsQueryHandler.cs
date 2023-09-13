using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetChildShoppingLists;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingListForCopy;
public class GetChildShoppingListsQueryHandler : IRequestHandler<GetChildShoppingListsQuery,
    GetChildShoppingListsVm> {
    private readonly IShoppingListService _shoppingListService;

    public GetChildShoppingListsQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<GetChildShoppingListsVm> Handle(GetChildShoppingListsQuery request,
        CancellationToken cancellationToken) {

        var childShoppingLists =  _shoppingListService.GetShoppingListsDtos(request.UserId)
            .Where(x => x.Id != request.ParentShoppingListId);

        return new GetChildShoppingListsVm {
            ParentShoppingListId = request.ParentShoppingListId,
            ChildShoppingLists = childShoppingLists
        };
    }
}
