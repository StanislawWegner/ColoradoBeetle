using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.DeleteGroup;
public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand> {
    private readonly IGroupService _groupService;
    private readonly IApplicationDbContext _context;

    public DeleteGroupCommandHandler(IGroupService groupService,
        IApplicationDbContext context)
    {
        _groupService = groupService;
        _context = context;
    }
    public async Task<Unit> Handle(DeleteGroupCommand request, 
        CancellationToken cancellationToken) {

        var groupDb = await _groupService.FindByIdAsync(request.Id);

        _context.Groups.Remove(groupDb);

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
