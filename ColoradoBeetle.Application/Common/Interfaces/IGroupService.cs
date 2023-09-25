using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IGroupService{

    Task ValidateGroupName(string name);
    IEnumerable<GroupDto> GetGroupsDtos();
    Task<Group> FindByIdAsync(int id);

}
