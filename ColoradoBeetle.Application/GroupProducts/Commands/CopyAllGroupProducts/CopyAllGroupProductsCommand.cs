using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CopyAllGroupProducts; 
public class CopyAllGroupProductsCommand : IRequest{
    public int PrntId { get; set; }
    public int ChildId { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
