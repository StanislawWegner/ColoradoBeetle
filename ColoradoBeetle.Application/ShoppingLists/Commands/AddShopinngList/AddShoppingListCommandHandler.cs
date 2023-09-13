using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.AddShopinngList;
internal class AddShoppingListCommandHandler : IRequestHandler<AddShoppingListCommand> {
    private readonly IShoppingListService _shoppingListService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IApplicationDbContext _context;

    public AddShoppingListCommandHandler(IShoppingListService shoppingListService,
        IDateTimeService dateTimeService,
        IApplicationDbContext context)
    {
        _shoppingListService = shoppingListService;
        _dateTimeService = dateTimeService;
        _context = context;
    }
    public async Task<Unit> Handle(AddShoppingListCommand request, 
        CancellationToken cancellationToken) {

        await _shoppingListService.ValidateShoppingListName(request.Name, request.UserId);

        var newName = !string.IsNullOrWhiteSpace(request.Name)
            ? request.Name : _dateTimeService.Now.ToString("F");


        await _context.ShoppingLists.AddAsync(new ShoppingList {
            Name = newName,
            UserId = request.UserId,
            CreatedDate = _dateTimeService.Now
        });

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
