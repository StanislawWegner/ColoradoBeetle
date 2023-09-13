using ColoradoBeetle.Application.ShoppingLists.Queries.GetChildShoppingLists;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingListForCopy; 
public class GetChildShoppingListsQuery : IRequest<GetChildShoppingListsVm>{
    public string UserId { get; set; }
    public int ParentShoppingListId { get; set; }
}
