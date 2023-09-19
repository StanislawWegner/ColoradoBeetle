using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.AddGroup;
public class AddGroupCommandHandler : IRequestHandler<AddGroupCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupService _groupService;

    public AddGroupCommandHandler(IApplicationDbContext context, IGroupService groupService)
    {
        _context = context;
        _groupService = groupService;
    }
    public async Task<Unit> Handle(AddGroupCommand request,
        CancellationToken cancellationToken) {

        await _groupService.ValidateGroupName(request.Name);

        await _context.Groups.AddAsync(new Domain.Entities.Group { Name = request.Name });

        await _context.SaveChangesAsync();

        return Unit.Value;

    }
}
