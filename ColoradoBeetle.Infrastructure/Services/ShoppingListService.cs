using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Services; 
public class ShoppingListService : IShoppingListService{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public ShoppingListService(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public async Task CreateAsync(string shoppingListName, string currentUserId) {

        await ValidateShoppingListName(shoppingListName);

        var newName = !string.IsNullOrWhiteSpace(shoppingListName) 
            ? shoppingListName : _dateTimeService.Now.ToString("F");


        await _context.ShoppingLists.AddAsync(new ShoppingList {
            Name = newName,
            UserId = currentUserId,
            CreatedDate = _dateTimeService.Now
        });

        await _context.SaveChangesAsync();
    }

    private async Task ValidateShoppingListName(string shoppingListName) {

        var shoppingListDb = await _context.ShoppingLists
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == shoppingListName);

        if(shoppingListDb != null) {
            throw new ValidationException(new List<ValidationFailure>
                { new ValidationFailure ("Name", 
                    $"Lista o nazwie '{shoppingListName}' już istnieje.")});
        }
    }

    public IEnumerable<ShoppingListDto> GetShoppingLists(string currentUserId) {

        return _context.ShoppingLists
            .AsNoTracking()
            .Where(x => x.UserId == currentUserId)
            .Select(x => new ShoppingListDto { Id = x.Id, Name = x.Name });
    }

    public async Task<ShoppingList> FindByIdAsync(int shoppingListId) {

        return await _context
            .ShoppingLists
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == shoppingListId);

    }

    public async Task UpdateAsync(ShoppingListDto shoppingListDto) {

        var shoppingList = await _context
            .ShoppingLists
            .FirstOrDefaultAsync(x => x.Id == shoppingListDto.Id);

        await ValidateShoppingListName(shoppingListDto.Name);

        shoppingList.Name = shoppingListDto.Name;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {

        var shoppingListDb = await _context
            .ShoppingLists
            .FirstOrDefaultAsync(x => x.Id == id);

        _context
            .ShoppingLists
            .Remove(shoppingListDb);

        await _context.SaveChangesAsync();
    }
}
