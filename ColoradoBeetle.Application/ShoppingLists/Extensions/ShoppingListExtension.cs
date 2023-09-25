using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.ShoppingLists.Extensions; 
public static class ShoppingListExtension {
    public static ShoppingListDto ToDto(this ShoppingList shoppingList) {

        if (shoppingList == null)
            return null;

        return new ShoppingListDto {
            Id = shoppingList.Id,
            Name = shoppingList.Name
        };
    }
}
