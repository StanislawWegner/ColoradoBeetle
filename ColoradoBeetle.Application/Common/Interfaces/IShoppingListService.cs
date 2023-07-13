using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IShoppingListService {
    Task CreateAsync(string shoppingListName, string currentUserId);
    IEnumerable<ShoppingListDto> GetShoppingLists(string currentUserId);
    Task<ShoppingList> FindByIdAsync(int shoppingListId);
    Task UpdateAsync(ShoppingListDto shoppingListDto);
    Task DeleteAsync(int id);
}
