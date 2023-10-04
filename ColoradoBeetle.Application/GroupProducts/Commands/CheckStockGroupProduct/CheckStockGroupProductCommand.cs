using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CheckStockGroupProduct; 
public class CheckStockGroupProductCommand : IRequest{
    public int Id { get; set; }
    public bool OnStock { get; set; }
    public string UserId { get; set; }
}
