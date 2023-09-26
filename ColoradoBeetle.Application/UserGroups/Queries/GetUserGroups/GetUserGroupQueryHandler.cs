using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.UserGroups.Queries.GetUserGroups;
public class GetUserGroupQueryHandler : IRequestHandler<GetUserGroupQuery,
    IEnumerable<GroupDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUserGroupQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GroupDto>> Handle(GetUserGroupQuery request,
        CancellationToken cancellationToken)
    {

        var user = await _context.Users
            .Include(x => x.Groups)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        return user.Groups.Select(x => x.ToDto());
    }
}
