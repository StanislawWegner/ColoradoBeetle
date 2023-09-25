using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IShoppingListService {
    IEnumerable<ShoppingListDto> GetShoppingListsDtos(string currentUserId);
    Task<ShoppingList> FindByIdAsync(int shoppingListId, string currentUserId);
    Task ValidateShoppingListName(string shoppingListName, string currentUserId);

}
