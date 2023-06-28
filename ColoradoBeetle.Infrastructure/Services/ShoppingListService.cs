using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Services; 
public class ShoppingListService : IShoppingListService{
    private readonly IApplicationDbContext _context;

    public ShoppingListService(IApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<ShoppingListDto> GetShoppingLists(string currentUser) {

        var shoppingLists = _context.ShoppingLists.Where(x => x.UserId == currentUser);

        return shoppingLists.Select(x => new ShoppingListDto { Id = x.Id, Name = x.Name });
    }
}
