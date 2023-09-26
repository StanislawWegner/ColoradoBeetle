using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using ColoradoBeetle.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.UserGroups.Queries.GetGroupMembers;
public class GetGroupMembersQueryHandler : IRequestHandler<GetGroupMembersQuery,
    GroupMemberVm> {
    private readonly IApplicationDbContext _context;

    public GetGroupMembersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GroupMemberVm> Handle(GetGroupMembersQuery request,
        CancellationToken cancellationToken) {

        var groupDB = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.GroupId);

        var members = groupDB.ApplicationUsers.Select(x => x.ToAppUserDto());

        if(members.Any(x => x.Id == request.UserId)) {
            return new GroupMemberVm {
                ApplicationUserDtos = members,
                GroupDto = groupDB.ToDto()
            };
        }
        else {
            return null;
        }

    }
}
