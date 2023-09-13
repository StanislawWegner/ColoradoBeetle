using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetEditShoppingList;
public class GetEditShoppingListQueryHandler : IRequestHandler<GetEditShoppingListQuery,
        EditShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;

    public GetEditShoppingListQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<EditShoppingListCommand> Handle(GetEditShoppingListQuery request, 
        CancellationToken cancellationToken) {

        var shoppingList = await _shoppingListService.FindByIdAsync(request.Id);

        return new EditShoppingListCommand {
            
            Id = shoppingList.Id,
            Name = shoppingList.Name,
            UserId = shoppingList.UserId
        };
    }
}
