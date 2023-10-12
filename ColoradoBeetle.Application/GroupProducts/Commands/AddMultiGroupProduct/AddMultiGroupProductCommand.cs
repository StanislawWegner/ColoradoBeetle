using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.GroupProducts.Commands.AddMultiGroupProduct; 
public class AddMultiGroupProductCommand : IRequest{

    [DisplayName("Produkty")]
    [Required(ErrorMessage = "To pole jest wymagane")]
    [MaxLength(400, ErrorMessage = "Maksymalna ilość znaków to '400'.")]
    public string MultiGroupProductNames { get; set; }
    public int GroupShopListId { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
