using ColoradoBeetle.Application.Roles.Commands.EditRole;
using MediatR;

namespace ColoradoBeetle.Application.Roles.Queries.GetEditRole;
public class GetEditRoleQuery : IRequest<EditRoleCommand> {
    public string Id { get; set; }
}
