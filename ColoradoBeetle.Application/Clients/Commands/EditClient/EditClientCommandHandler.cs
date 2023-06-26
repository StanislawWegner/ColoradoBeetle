using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Clients.Commands.EditClient;
public class EditClientCommandHandler : IRequestHandler<EditClientCommand> {
    private readonly IApplicationDbContext _context;

    public EditClientCommandHandler(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<Unit> Handle(EditClientCommand request
        , CancellationToken cancellationToken) {

        var user = await _context.Users
            .Include(x => x.Client)
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        if (user.Client == null)
            user.Client = new Domain.Entities.Client();

        user.Client.UserId = request.Id;

        if (user.Address == null)
            user.Address = new Domain.Entities.Address();

        user.Address.Country = request.Country;
        user.Address.City = request.City;
        user.Address.Street = request.Street;
        user.Address.ZipCode = request.ZipCode;
        user.Address.StreetNumber = request.StreetNumber;
        user.Address.UserId = request.Id;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
