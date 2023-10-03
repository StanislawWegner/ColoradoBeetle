using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetChildGroupProducts; 
public class GetChildGroupProductsQuery : IRequest<GetChildGroupProductsVm> {
    public int ChildId { get; set; }
    public int PrntId { get; set; }
    public string UserId { get; set; }
    public int GroupId { get; set; }
}
