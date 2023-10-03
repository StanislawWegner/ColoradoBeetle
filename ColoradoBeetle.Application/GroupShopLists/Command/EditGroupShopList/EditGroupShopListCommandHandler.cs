using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Command.EditGroupShopList;
public class EditGroupShopListCommandHandler : IRequestHandler<EditGroupShopListCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupShopListService _groupShopListService;

    public EditGroupShopListCommandHandler(IApplicationDbContext context, 
        IGroupShopListService groupShopListService)
    {
        _context = context;
        _groupShopListService = groupShopListService;
    }
    public async Task<Unit> Handle(EditGroupShopListCommand request, 
        CancellationToken cancellationToken) {

        var groupShopListDb = await _groupShopListService.FindGroupShopListByIdAsync(request.Id);

        if(groupShopListDb.Name != request.Name) {
            await _groupShopListService
            .ValidateGroupShopListName(request.Name, request.GroupId);
        }
        
        groupShopListDb.Name = request.Name;
        groupShopListDb.UserId = request.UserId;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
