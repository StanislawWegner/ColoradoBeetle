using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CheckGroupProduct; 
public class CheckGroupProductCommand : IRequest{
    public int Id { get; set; }
    public bool IsChecked { get; set; }
    public string UserId { get; set; }
}
