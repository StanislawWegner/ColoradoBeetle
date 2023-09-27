using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupShopLists.Command.DeleteGroupShopList;
public class DeleteGroupShopListCommandHandler : IRequestHandler<DeleteGroupShopListCommand> 
    {
    private readonly IApplicationDbContext _context;
    private readonly IGroupShopListService _groupShopListService;

    public DeleteGroupShopListCommandHandler(IApplicationDbContext context, 
        IGroupShopListService groupShopListService)
    {
        _context = context;
        _groupShopListService = groupShopListService;
    }
    public async Task<Unit> Handle(DeleteGroupShopListCommand request,
        CancellationToken cancellationToken) {

        var groupShopListDb = await _groupShopListService.FindGroupShopListById(request.Id);

        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == groupShopListDb.GroupId);

        var isUserInGroup = groupDb.ApplicationUsers.Any(x => x.Id == request.UserId);

        if (isUserInGroup) {
            _context.GroupShopLists.Remove(groupShopListDb);

            await _context.SaveChangesAsync();
        }

        return Unit.Value;
    }
}
