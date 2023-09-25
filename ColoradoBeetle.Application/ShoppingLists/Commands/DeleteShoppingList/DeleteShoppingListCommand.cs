using MediatR;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.DeleteShoppingList; 
public class DeleteShoppingListCommand : IRequest{
    public int Id { get; set; }
    public string UserId { get; set; }
}
