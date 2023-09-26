using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;
using MediatR;

namespace ColoradoBeetle.Application.UserGroups.Queries.GetGroupMembers; 
public class GetGroupMembersQuery : IRequest<GroupMemberVm> {
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
