using ColoradoBeetle.Application.Roles.Queries.GetRoles;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IRoleManagerService {
    Task CreateAsync(string roleName);
    Task DeleteAsync(string id);
    Task<RoleDto> FindByIdAsync(string id);
    IEnumerable<RoleDto> GetRoles();
    Task UpdateAsync(RoleDto role);
}
