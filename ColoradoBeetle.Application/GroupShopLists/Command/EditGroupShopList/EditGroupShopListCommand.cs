using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList; 
public class EditGroupShopListCommand : IRequest{
    public int Id { get; set; }

    [Required]
    [DisplayName("Nazwa listy")]
    [MaxLength(50, ErrorMessage = "Maksymalna liczba znaków '50'.")]
    public string Name { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }

}
