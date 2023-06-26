using ColoradoBeetle.Application.Clients.Commands.EditClient;
using ColoradoBeetle.Application.Clients.Queries.GetClient;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Users.Extensions; 
public static class UserExtensions {
    public static ClientDto ToClientDto(this ApplicationUser user) {
        
        if (user == null)
            return null;

        return new ClientDto {
            Id = user.Id,
            City = user.Address?.City,
            Country = user.Address?.Country,
            Street = user.Address?.Street,
            StreetNumber = user.Address?.StreetNumber,
            ZipCode = user.Address?.ZipCode,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }

    public static EditClientCommand ToEditClientCommand(this ApplicationUser user) {

        if (user == null)
            return null;

        return new EditClientCommand {
            Id = user.Id,
            City = user.Address?.City,
            Country = user.Address?.Country,
            Street = user.Address?.Street,
            StreetNumber = user.Address?.StreetNumber,
            ZipCode = user.Address?.ZipCode,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}
