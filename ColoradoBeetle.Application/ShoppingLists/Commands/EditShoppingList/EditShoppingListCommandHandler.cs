using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
public class EditShoppingListCommandHandler : IRequestHandler<EditShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;

    public EditShoppingListCommandHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<Unit> Handle(EditShoppingListCommand request, 
        CancellationToken cancellationToken) {

        await _shoppingListService.UpdateAsync(new ShoppingListDto 
        { 
            Id = request.Id,
            Name = request.Name

        });

        return Unit.Value;

    }
}
