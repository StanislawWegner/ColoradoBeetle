using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CheckProduct; 
public class CheckProductCommand : IRequest{
    public int Id { get; set; }
    public bool IsChecked { get; set; }
    public string UserId { get; set; }
}
