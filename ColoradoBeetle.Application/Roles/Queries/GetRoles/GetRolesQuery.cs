using MediatR;

namespace ColoradoBeetle.Application.Roles.Queries.GetRoles; 
public class GetRolesQuery : IRequest<IEnumerable<RoleDto>>{
}
