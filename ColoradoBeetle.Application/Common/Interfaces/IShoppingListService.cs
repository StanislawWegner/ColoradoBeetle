using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IShoppingListService {
    Task CreateAsync(string shoppingListName, string currentUserId);
    IEnumerable<ShoppingListDto> GetShoppingLists(string currentUserId);
}
