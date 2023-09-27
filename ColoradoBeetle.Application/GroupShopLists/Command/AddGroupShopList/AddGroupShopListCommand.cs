using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.GroupShopLists.Command.AddGroupShopList; 
public class AddGroupShopListCommand : IRequest{

    [Required(ErrorMessage = "Wpisz nazwę listy zakupów")]
    [DisplayName("Nazwa listy")]
    [MaxLength(50, ErrorMessage = "Maksymalna liczba znaków '50'.")]
    public string Name { get; set; }
    public string UserId { get; set; }
    public int GroupId { get; set; }
}
