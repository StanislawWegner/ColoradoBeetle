using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IShoppingListService {

    IEnumerable<ShoppingListDto> GetShoppingLists(string currentUserId);
}
