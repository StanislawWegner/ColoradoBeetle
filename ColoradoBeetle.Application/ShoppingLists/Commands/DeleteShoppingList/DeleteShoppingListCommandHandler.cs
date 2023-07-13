using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.DeleteShoppingList;
public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;

    public DeleteShoppingListCommandHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<Unit> Handle(DeleteShoppingListCommand request, 
        CancellationToken cancellationToken) {

        await _shoppingListService.DeleteAsync(request.Id);

        return Unit.Value;
    }
}
