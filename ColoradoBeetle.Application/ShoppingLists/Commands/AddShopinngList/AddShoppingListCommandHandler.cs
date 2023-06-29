using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.AddShopinngList;
internal class AddShoppingListCommandHandler : IRequestHandler<AddShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;

    public AddShoppingListCommandHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<Unit> Handle(AddShoppingListCommand request, 
        CancellationToken cancellationToken) {

        await _shoppingListService.CreateAsync(request.Name, request.UserId);

        return Unit.Value;
    }
}
