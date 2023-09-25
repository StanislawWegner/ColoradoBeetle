using ColoradoBeetle.Application.Groups.Commands.EditGroup;
using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetEditGroup; 
public class GetEditGroupQuery : IRequest<EditGroupCommand> {
    public int Id { get; set; }
}
