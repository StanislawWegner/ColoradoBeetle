using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ColoradoBeetle.Infrastructure.Services;
public class UserRoleManagerService : IUserRoleManagerService {
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRoleManagerService(UserManager<ApplicationUser> userManager) {
        _userManager = userManager;
    }
    public async Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string roleName) {

        return await _userManager.GetUsersInRoleAsync(roleName);
    }
}
