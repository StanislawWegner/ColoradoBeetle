using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.Groups.Commands.AddGroup; 
public class AddGroupCommand : IRequest{

    [Required(ErrorMessage = "Podaj nazwę grupy.")]
    [DisplayName("Nazwa grupy")]
    [MaxLength(50, ErrorMessage = "Maksymalna liczba znaków to '50'.")]
    public string Name { get; set; }
}
