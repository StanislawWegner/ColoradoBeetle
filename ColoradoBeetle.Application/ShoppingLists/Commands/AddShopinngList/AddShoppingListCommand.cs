using MediatR;
using System.ComponentModel;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.AddShopinngList; 
public class AddShoppingListCommand : IRequest{

    [DisplayName("Nazwa listy")]
    public string Name { get; set; }
    public string UserId { get; set; }

}
