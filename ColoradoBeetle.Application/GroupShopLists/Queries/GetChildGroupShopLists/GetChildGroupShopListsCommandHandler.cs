using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupShopLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetChildGroupShopLists;
public class GetChildGroupShopListsCommandHandler : IRequestHandler<GetChildGroupShopListsCommand,
    ChildGroupShopListsVm> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupShopListService _groupShopListService;

    public GetChildGroupShopListsCommandHandler(IApplicationDbContext context, 
        IGroupShopListService groupShopListService)
    {
        _context = context;
        _groupShopListService = groupShopListService;
    }

    public async Task<ChildGroupShopListsVm> Handle(GetChildGroupShopListsCommand request,
        CancellationToken cancellationToken) {

        var isUserInGroup = await _groupShopListService.IsUserInGroup(request.GroupId,
            request.UserId);

        if (isUserInGroup) {
            
            var childGroupShopListsDtos = _context.GroupShopLists
            .Include(x => x.ApplicationUser)
            .AsNoTracking()
            .Where(x => x.Id != request.PrntId)
            .Select(x => x.ToDto());

            return new ChildGroupShopListsVm {
                PrntId = request.PrntId,
                ChildGroupShopListsDtos = childGroupShopListsDtos,
                GroupId = request.GroupId
            };
        }
        else {
            throw new NotImplementedException();
        }
        
    }
}
