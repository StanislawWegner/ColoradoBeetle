using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CheckStockProduct; 
public class CheckStockProductCommand : IRequest{
    public int Id { get; set; }
    public bool OnStock { get; set; }
}
