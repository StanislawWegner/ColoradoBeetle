using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IUserRoleManagerService {

    Task<IEnumerable<ApplicationUser>> GetUsersInRoleAsync(string roleName);
}
