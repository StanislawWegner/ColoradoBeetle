using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Command.AddGroupShopList;
public class AddGroupShopListCommandHandler : IRequestHandler<AddGroupShopListCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IGroupShopListService _groupShopListService;

    public AddGroupShopListCommandHandler(IApplicationDbContext context, 
        IDateTimeService dateTimeService,
        IGroupShopListService groupShopListService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _groupShopListService = groupShopListService;
    }
    public async Task<Unit> Handle(AddGroupShopListCommand request,
        CancellationToken cancellationToken) {

        await _groupShopListService.ValidateGroupShopListName(request.Name, request.GroupId);

        await _context.GroupShopLists.AddAsync( new GroupShopList {
            Name = request.Name,
            UserId = request.UserId,
            GroupId = request.GroupId,
            CreatedDate = _dateTimeService.Now
        });

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
