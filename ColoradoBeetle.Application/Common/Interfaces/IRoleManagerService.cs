using ColoradoBeetle.Application.Roles.Queries.GetRoles;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IRoleManagerService {
    Task CreateAsync(string roleName);
    IEnumerable<RoleDto> GetRoles();
}
