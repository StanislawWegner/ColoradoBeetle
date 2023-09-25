using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Queries.GetUserGroups;
public class GetUserGroupQueryHandler : IRequestHandler<GetUserGroupQuery,
    IEnumerable<GroupDto>> {
    private readonly IApplicationDbContext _context;

    public GetUserGroupQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GroupDto>> Handle(GetUserGroupQuery request, 
        CancellationToken cancellationToken) {

        var groupsIds = (await _context.ApplicationUserGroups
            .Where(x => x.UserId == request.UserId)
            .ToListAsync()).Select(x => x.GroupId);

        var groups = await _context.Groups.ToListAsync();

        var userGroups = new List<Group>();

        foreach (var id in groupsIds) {
            foreach (var group in groups) {
                if(id == group.Id)
                    userGroups.Add(group);
            }
        }

        return userGroups.Select(x => x.ToDto());
    }
}
