using ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList;
using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetEditGroupShopList; 
public class GetEditGroupShopListQuery : IRequest<EditGroupShopListCommand> {
    public int Id { get; set; }
    public string UserId { get; set; }
}
