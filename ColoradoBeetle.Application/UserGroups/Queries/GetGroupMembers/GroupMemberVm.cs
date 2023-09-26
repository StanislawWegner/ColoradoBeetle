using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;

namespace ColoradoBeetle.Application.UserGroups.Queries.GetGroupMembers; 
public class GroupMemberVm {
    public GroupDto GroupDto { get; set; }
    public IEnumerable<ApplicationUserDto> ApplicationUserDtos { get; set; }
}
