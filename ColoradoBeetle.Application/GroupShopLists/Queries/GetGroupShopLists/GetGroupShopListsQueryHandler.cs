using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ColoradoBeetle.Application.GroupShopLists.Extensions;
using System.Security.Cryptography.X509Certificates;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Users.Extensions;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopLists;
public class GetGroupShopListsQueryHandler : IRequestHandler<GetGroupShopListsQuery,
    GroupShopListsVm> {
    private readonly IApplicationDbContext _context;

    public GetGroupShopListsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GroupShopListsVm> Handle(GetGroupShopListsQuery request,
        CancellationToken cancellationToken) {

        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.GroupId);

        var groupShopListsDtos = _context.GroupShopLists
            .Include(x => x.ApplicationUser)
            .Where(x => x.GroupId == request.GroupId)
            .Select(x => x.ToDto());

        if (groupDb.ApplicationUsers.Any(x => x.Id == request.UserId)) {
            return new GroupShopListsVm {
                GroupDto = groupDb.ToDto(),
                GroupShopListsDtos = groupShopListsDtos
            };
        }
        else {
            return null;
        }
    }
}
