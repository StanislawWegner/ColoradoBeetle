using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Roles.Queries.GetRoles;
using Microsoft.AspNetCore.Identity;

namespace ColoradoBeetle.Infrastructure.Services;
public class RoleManagerService : IRoleManagerService {
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagerService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public IEnumerable<RoleDto> GetRoles() {

        return _roleManager.Roles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList();
    }
}
