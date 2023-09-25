using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Commands.RemoveUserFromGroup;
public class RemoveUserFromGroupCommandHandler : IRequestHandler<RemoveUserFromGroupCommand> {
    private readonly IApplicationDbContext _context;

    public RemoveUserFromGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(RemoveUserFromGroupCommand request, 
        CancellationToken cancellationToken) {

        var appUserGroupDb = await _context.ApplicationUserGroups
            .FirstOrDefaultAsync(x => x.UserId == request.UserId
                && x.GroupId == request.GroupId);

        _context.ApplicationUserGroups.Remove(appUserGroupDb);

        await _context.SaveChangesAsync();

        return Unit.Value;

    }
}
