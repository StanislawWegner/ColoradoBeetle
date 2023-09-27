using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList;
using ColoradoBeetle.Application.GroupShopLists.Extensions;
using ColoradoBeetle.Application.ShoppingLists.Commands.EditShoppingList;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetEditGroupShopList;
public class GetEditGroupShopListQueryHandler : IRequestHandler<GetEditGroupShopListQuery,
    EditGroupShopListCommand> {
    private readonly IGroupShopListService _groupShopListService;
    private readonly IApplicationDbContext _context;

    public GetEditGroupShopListQueryHandler(IGroupShopListService groupShopListService, 
        IApplicationDbContext context)
    {
        _groupShopListService = groupShopListService;
        _context = context;
    }
    public async Task<EditGroupShopListCommand> Handle(GetEditGroupShopListQuery request, 
        CancellationToken cancellationToken) {

        var groupShopList = await _groupShopListService
            .FindGroupShopListById(request.Id);

        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == groupShopList.GroupId);

        var isUserInGroup = groupDb.ApplicationUsers
            .FirstOrDefault(x => x.Id == request.UserId);

        if(isUserInGroup != null) {
            return new EditGroupShopListCommand {
                Id = request.Id,
                GroupId = groupShopList.GroupId,
                Name = groupShopList.Name,
                UserId = request.UserId
            };
        }
        else {
            return null;
        }
    }
}
