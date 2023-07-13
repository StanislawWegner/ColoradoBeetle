using ColoradoBeetle.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ColoradoBeetle.Application.Products.Commands.AddProduct; 
public class AddProductCommand : IRequest{

    [Required(ErrorMessage = "Pole 'nazwa produktu' jest wymagane.")]
    [DisplayName("Nazwa produktu")]
    public string Name { get; set; }

    [DisplayName("Ilość")]
    public int Quantity { get; set; }
    [DisplayName("Objętość")]
    public int Volume { get; set; }
    [DisplayName("Jednostka objętosci")]
    public VolumeUnit VolumeUnit { get; set; }
    [DisplayName("Masa")]
    public int Weight { get; set; }
    [DisplayName("Jednostka masy")]
    public WeightUnit WeightUnit { get; set; }

    public int ShoppingListId { get; set; }
}
