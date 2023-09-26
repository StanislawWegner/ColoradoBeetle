using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using ColoradoBeetle.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersDtos;
public class GetUsersToAddQueryHandler : IRequestHandler<GetUsersToAddDtosQuery, UsersInGroupVm> {
    private readonly IApplicationDbContext _context;

    public GetUsersToAddQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<UsersInGroupVm> Handle(GetUsersToAddDtosQuery request, 
        CancellationToken cancellationToken) {

        var usersDtos =  (await _context.Users
            .AsNoTracking()
            .ToListAsync())
            .Select(x => x.ToAppUserDto());

        var groupDto = (await _context.Groups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.GroupId))
            .ToDto();

        return new UsersInGroupVm { 
            GroupDto = groupDto,
            UsersDtos = usersDtos
        };
    }
}
