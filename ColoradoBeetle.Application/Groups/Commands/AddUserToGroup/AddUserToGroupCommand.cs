using MediatR;

namespace ColoradoBeetle.Application.Groups.Commands.AddUserToGroup; 
public class AddUserToGroupCommand : IRequest{

    public string UserId { get; set; }
    public int GroupId { get; set; }
}
