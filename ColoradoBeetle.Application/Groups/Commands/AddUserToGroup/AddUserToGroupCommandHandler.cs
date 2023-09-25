using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.AddUserToGroup;
public class AddUserToGroupCommandHandler : IRequestHandler<AddUserToGroupCommand> {
    private readonly IApplicationDbContext _context;

    public AddUserToGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(AddUserToGroupCommand request,
        CancellationToken cancellationToken) {

        var appUserGroup = new ApplicationUserGroup {

            UserId = request.UserId,
            GroupId = request.GroupId
        };

        await _context.ApplicationUserGroups
            .AddAsync(appUserGroup);

        await _context.SaveChangesAsync();

        return Unit.Value;  
    }
}
