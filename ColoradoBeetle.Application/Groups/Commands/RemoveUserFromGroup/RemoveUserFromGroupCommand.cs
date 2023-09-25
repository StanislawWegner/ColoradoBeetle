using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.RemoveUserFromGroup; 
public class RemoveUserFromGroupCommand : IRequest{
    public string UserId { get; set; }
    public int GroupId { get; set; }
}
