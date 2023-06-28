using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists; 
public class GetShoppingListsQuery : IRequest<IEnumerable<ShoppingListDto>>{
    public string UserId { get; set; }
}
