using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.Products.Commands.AddMultiProducts; 
public class AddMultiProductCommand : IRequest{

    [Required(ErrorMessage = "To pole jest obowiązkowe.")]
    [MaxLength(400, ErrorMessage = "Maksymalna liczba znaków to 400.")]
    [DisplayName("Produkty")]
    public string MultiProductsNames { get; set; }

    public int ShoppingListId { get; set; }
    public string UserId { get; set; }
    
}
