using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Groups.Commands.EditGroup;
using ColoradoBeetle.Application.Groups.Extenions;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetEditGroup;
public class GetEditGroupQueryHandler : IRequestHandler<GetEditGroupQuery, EditGroupCommand> {
    private readonly IGroupService _groupService;

    public GetEditGroupQueryHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public async Task<EditGroupCommand> Handle(GetEditGroupQuery request,
        CancellationToken cancellationToken) {

        var groupDb = await _groupService.FindByIdAsync(request.Id);

        return new EditGroupCommand { Id = groupDb.Id, Name = groupDb.Name };
    }
}
