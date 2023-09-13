using ColoradoBeetle.Application.Clients.Commands.EditClient;
using MediatR;

namespace Colorado.Application.Clients.Queries.GetEditClient;
public class GetEditClientQuery : IRequest<EditClientCommand> {
    public string UserId { get; set; }
}
