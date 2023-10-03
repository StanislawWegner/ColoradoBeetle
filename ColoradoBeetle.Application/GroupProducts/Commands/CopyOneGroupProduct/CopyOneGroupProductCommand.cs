using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CopyOneGroupProduct; 
public class CopyOneGroupProductCommand : IRequest{
    public int Id { get; set; }
    public int PrntId { get; set; }
    public string UserId { get; set; }
}
