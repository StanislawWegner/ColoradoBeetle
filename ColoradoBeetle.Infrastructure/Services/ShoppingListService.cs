using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Services; 
public class ShoppingListService : IShoppingListService{
    private readonly IApplicationDbContext _context;

    public ShoppingListService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ValidateShoppingListName(string shoppingListName, string currentUserId) {

        var shoppingListDb = await _context.ShoppingLists
            .AsNoTracking()
            .Where(x => x.UserId == currentUserId)
            .FirstOrDefaultAsync(x => x.Name == shoppingListName);

        if(shoppingListDb != null) {
            throw new ValidationException(new List<ValidationFailure>
                { new ValidationFailure ("Name", 
                    $"Lista o nazwie '{shoppingListName}' już istnieje.")});
        }
    }

    public IEnumerable<ShoppingListDto> GetShoppingListsDtos(string currentUserId) {

        return _context.ShoppingLists
            .AsNoTracking()
            .Where(x => x.UserId == currentUserId)
            .Select(x => new ShoppingListDto { Id = x.Id, 
                Name = x.Name,
                CreatedDate = x.CreatedDate
            });

    }

    public async Task<ShoppingList> FindByIdAsync(int shoppingListId, string currentUserId) {
        
        return await _context
           .ShoppingLists
           .FirstOrDefaultAsync(x => x.Id == shoppingListId && x.UserId == currentUserId);
    }

    

    

    
}
