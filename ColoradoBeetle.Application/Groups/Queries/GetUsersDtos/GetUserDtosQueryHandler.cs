using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using ColoradoBeetle.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersDtos;
public class GetUserDtosQueryHandler : IRequestHandler<GetUserDtosQuery, UsersInGroupVm> {
    private readonly IApplicationDbContext _context;

    public GetUserDtosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<UsersInGroupVm> Handle(GetUserDtosQuery request, 
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
