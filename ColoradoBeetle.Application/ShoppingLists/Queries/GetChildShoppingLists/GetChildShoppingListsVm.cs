using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetChildShoppingLists; 
public class GetChildShoppingListsVm {
    public int ParentShoppingListId { get; set; }
    public IEnumerable<ShoppingListDto> ChildShoppingLists { get; set; }
}
