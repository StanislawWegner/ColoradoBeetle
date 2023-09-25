using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList; 
public class EditShoppingListCommand : IRequest{

    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę listy zakupów.")]
    [DisplayName("Nazwa listy")]
    public string Name { get; set; }
    public string UserId { get; set; }
}
