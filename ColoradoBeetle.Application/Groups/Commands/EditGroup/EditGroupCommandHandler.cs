using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.EditGroup;
public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand> {
    private readonly IGroupService _groupService;
    private readonly IApplicationDbContext _context;

    public EditGroupCommandHandler(IGroupService groupService,
        IApplicationDbContext context)
    {
        _groupService = groupService;
        _context = context;
    }
    public async Task<Unit> Handle(EditGroupCommand request, 
        CancellationToken cancellationToken) {

        var groupDb = await _groupService.FindByIdAsync(request.Id);

        if(groupDb.Name != request.Name)
            await _groupService.ValidateGroupName(request.Name);

        groupDb.Name = request.Name;

        await _context.SaveChangesAsync();

        return Unit.Value;

    }
}
