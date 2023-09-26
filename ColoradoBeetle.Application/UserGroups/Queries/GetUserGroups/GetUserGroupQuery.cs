using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using MediatR;

namespace ColoradoBeetle.Application.UserGroups.Queries.GetUserGroups;
public class GetUserGroupQuery : IRequest<IEnumerable<GroupDto>>
{
    public string UserId { get; set; }
}
