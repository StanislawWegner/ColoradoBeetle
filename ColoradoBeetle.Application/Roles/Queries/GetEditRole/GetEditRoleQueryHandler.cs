using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Roles.Commands.EditRole;
using MediatR;

namespace ColoradoBeetle.Application.Roles.Queries.GetEditRole;
public class GetEditRoleQueryHandler : IRequestHandler<GetEditRoleQuery, EditRoleCommand> {
    private readonly IRoleManagerService _roleManagerService;

    public GetEditRoleQueryHandler(IRoleManagerService roleManagerService) {
        _roleManagerService = roleManagerService;
    }   
    public async Task<EditRoleCommand> Handle(GetEditRoleQuery request,
        CancellationToken cancellationToken) {

        var role = await _roleManagerService.FindByIdAsync(request.Id);

        return new EditRoleCommand { Id = role.Id, Name = role.Name };

    }
}
