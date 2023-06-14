using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Application.Contacts.Commands.SendContactEmail; 
public class SendContactEmailCommand : IRequest{

    [Required(ErrorMessage = "Pole 'Imię i nazwisko' jest wymagane.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Pole 'e-mail' jest wymagane.")]
    [EmailAddress(ErrorMessage = "Podaj prawidłowy format e-mail")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Pole 'Tytuł wiadomości' jest wymagane")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Pole 'Wiadomość' jest wymagane")]
    public string Message { get; set; }

    public string AntySpamResult { get; set; }
}
