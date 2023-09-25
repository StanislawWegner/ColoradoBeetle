using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup; 
public class UsersInGroupVm {

    public IEnumerable<ApplicationUserDto> UsersDtos { get; set; }
    public GroupDto GroupDto { get; set; }
}
