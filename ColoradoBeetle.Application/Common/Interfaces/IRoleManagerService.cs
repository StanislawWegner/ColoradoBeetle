using ColoradoBeetle.Application.Roles.Queries.GetRoles;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IRoleManagerService {
    IEnumerable<RoleDto> GetRoles();
}
