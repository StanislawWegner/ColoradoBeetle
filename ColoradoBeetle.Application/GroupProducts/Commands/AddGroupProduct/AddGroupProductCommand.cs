using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ColoradoBeetle.Domain.Enums;

namespace ColoradoBeetle.Application.GroupProducts.Commands.AddGroupProduct; 
public class AddGroupProductCommand : IRequest{

    [Required(ErrorMessage = "To pole jest obowiązkowe.")]
    [DisplayName("Nazwa produktu")]
    [MaxLength(50, ErrorMessage = "Maksymalna liczba znaków '50'.")]
    public string Name { get; set; }

    [RegularExpression("([0-9]+)", ErrorMessage = "Podaj liczbę naturalną")]
    [DisplayName("Ilość")]
    public int? Quantity { get; set; }

    [RegularExpression("([0-9]+)", ErrorMessage = "Podaj liczbę naturalną")]
    [DisplayName("Objętość")]
    public int? Volume { get; set; }

    [DisplayName("Wybierz")]
    public VolumeUnit? VolumeUnit { get; set; }

    [RegularExpression("([0-9]+)", ErrorMessage = "Podaj liczbę naturalną")]
    [DisplayName("Masa")]
    public int? Weight { get; set; }

    [DisplayName("Wybierz")]
    public WeightUnit? WeightUnit { get; set; }

    public string UserId { get; set; }
    public int GroupShopListId { get; set; }
    public int GroupId { get; set; }
}
