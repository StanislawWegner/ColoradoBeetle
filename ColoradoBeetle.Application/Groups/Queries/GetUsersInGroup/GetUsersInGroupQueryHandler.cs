using ColoradoBeetle.Application.Clients.Queries.GetClient;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Users.Extensions;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
public class GetUsersInGroupQueryHandler : IRequestHandler<GetUsersInGroupQuery,
    UsersInGroupVm> {
    private readonly IApplicationDbContext _context;

    public GetUsersInGroupQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UsersInGroupVm> Handle(GetUsersInGroupQuery request, 
        CancellationToken cancellationToken) {

        var groupDb =  await _context.Groups
            .Include(x => x.ApplicationUsers)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var appUsersDtos = groupDb.ApplicationUsers.Select(x => x.ToAppUserDto());
        
        return new UsersInGroupVm {
            GroupDto = groupDb.ToDto(),
            UsersDtos = appUsersDtos
        };
    }
}
