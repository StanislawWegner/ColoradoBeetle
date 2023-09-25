using ColoradoBeetle.Application.Clients.Queries.GetClient;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup; 
public class GetUsersInGroupQuery : IRequest<IEnumerable<ClientDto>>{
    public int Id { get; set; }
}
