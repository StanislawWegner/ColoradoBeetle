using ColoradoBeetle.Application.Clients.Queries.GetClient;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Users.Extensions;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
public class GetUsersInGroupQueryHandler : IRequestHandler<GetUsersInGroupQuery,
    IEnumerable<ClientDto>> {
    private readonly IApplicationDbContext _context;

    public GetUsersInGroupQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientDto>> Handle(GetUsersInGroupQuery request, 
        CancellationToken cancellationToken) {

        var appUserGroup = await _context.ApplicationUserGroups
            .Where(x => x.GroupId == request.Id)
            .ToListAsync();

        var users = await _context.Users
            .Include(x => x.Client)
            .Include(x => x.Address)
            .ToListAsync();

        var grUsers = new List<ApplicationUser>();

        foreach (var userGr in appUserGroup) {
            foreach ( var user in users) {
                if(user.Id == userGr.UserId) {
                    grUsers.Add(user);
                }
            }
        }

        return grUsers.Select(x => x.ToClientDto());
        
    }
}
