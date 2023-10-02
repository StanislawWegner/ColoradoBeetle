using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.DeleteGroupProduct; 
public class DeleteGroupProductCommand : IRequest{
    public int Id { get; set; }
    public string UserId { get; set; }
}
