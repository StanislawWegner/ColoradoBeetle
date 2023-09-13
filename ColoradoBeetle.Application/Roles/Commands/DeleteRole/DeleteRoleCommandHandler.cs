﻿using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Roles.Commands.DeleteRole;
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand> {
    private readonly IRoleManagerService _roleManagerService;

    public DeleteRoleCommandHandler(IRoleManagerService roleManagerService) {
        _roleManagerService = roleManagerService;
    }
    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken) {

        await _roleManagerService.DeleteAsync(request.Id);

        return Unit.Value;
    }
}
