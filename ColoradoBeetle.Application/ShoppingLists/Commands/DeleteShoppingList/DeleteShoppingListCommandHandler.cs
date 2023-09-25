using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.DeleteShoppingList;
public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;
    private readonly IApplicationDbContext _context;

    public DeleteShoppingListCommandHandler(IShoppingListService shoppingListService,
        IApplicationDbContext context)
    {
        _shoppingListService = shoppingListService;
        _context = context;
    }
    public async Task<Unit> Handle(DeleteShoppingListCommand request, 
        CancellationToken cancellationToken) {

        var shoppingListDb = await _shoppingListService.FindByIdAsync(request.Id, request.UserId);

        _context.ShoppingLists.Remove(shoppingListDb);

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
