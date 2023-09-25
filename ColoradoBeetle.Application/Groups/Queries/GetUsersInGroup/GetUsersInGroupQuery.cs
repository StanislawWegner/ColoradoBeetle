using ColoradoBeetle.Application.Clients.Queries.GetClient;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup; 
public class GetUsersInGroupQuery : IRequest<UsersInGroupVm> {
    public int Id { get; set; }
}
