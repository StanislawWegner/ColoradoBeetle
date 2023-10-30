using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupProducts.Extensions;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.GroupShopLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetGroupProducts;
public class GetGroupProductsQueryHandler : IRequestHandler<GetGroupProductsQuery,
    GroupProductVm> {
    private readonly IApplicationDbContext _context;

    public GetGroupProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GroupProductVm> Handle(GetGroupProductsQuery request, 
        CancellationToken cancellationToken) {

        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.GroupId);

        var isUserInGroup = groupDb.ApplicationUsers.Any(x => x.Id == request.UserId);

        if (isUserInGroup) {

            var groupProductsDtos = _context.GroupProducts
            .Include(x => x.ApplicatioUser)
            .AsNoTracking()
            .Where(x => x.GroupShopListId == request.GroupShopListId)
            .Select(x => x.ToDto());

            var groupShopListDto= (await _context.GroupShopLists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.GroupShopListId))
                .ToDto();

            return new GroupProductVm {
                GroupProductsDtos = groupProductsDtos,
                GroupShopListDto = groupShopListDto,
                GroupDto = groupDb.ToDto()
            };
        }
        else {
            return null;
        }
    }
}
