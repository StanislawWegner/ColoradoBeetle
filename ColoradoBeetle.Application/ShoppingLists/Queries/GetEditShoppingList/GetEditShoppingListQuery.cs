using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Queries.GetEditShoppingList; 
public class GetEditShoppingListQuery : IRequest<EditShoppingListCommand>{
    public int Id { get; set; }
}
