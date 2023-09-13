using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
public class EditShoppingListCommandHandler : IRequestHandler<EditShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;
    private readonly IApplicationDbContext _context;

    public EditShoppingListCommandHandler(IShoppingListService shoppingListService,
        IApplicationDbContext context)
    {
        _shoppingListService = shoppingListService;
        _context = context;
    }
    public async Task<Unit> Handle(EditShoppingListCommand request, 
        CancellationToken cancellationToken) {

        var shoppngListDb = await _shoppingListService.FindByIdAsync(request.Id);

        if (shoppngListDb.Name != request.Name)
            await _shoppingListService.ValidateShoppingListName(request.Name, 
                request.UserId);

        shoppngListDb.Name = request.Name;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
