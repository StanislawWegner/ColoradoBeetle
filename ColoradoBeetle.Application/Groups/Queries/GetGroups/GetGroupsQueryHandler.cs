using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetGroups;
public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IEnumerable<GroupDto>> {
    private readonly IGroupService _groupService;

    public GetGroupsQueryHandler(IGroupService groupService)
    {
        _groupService = groupService;
    }
    public async Task<IEnumerable<GroupDto>> Handle(GetGroupsQuery request,
        CancellationToken cancellationToken) {

        return _groupService.GetGroupsDtos();


    }
}
