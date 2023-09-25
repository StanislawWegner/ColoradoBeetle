using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.Groups.Commands.EditGroup; 
public class EditGroupCommand : IRequest{
    public int Id { get; set; }

    [Required(ErrorMessage = "Podaj nazwę grupy.")]
    [DisplayName("Nazwa grupy")]
    public string Name { get; set; }
}
