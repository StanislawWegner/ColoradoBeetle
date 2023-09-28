using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetGroupProducts; 
public class GetGroupProductsQuery : IRequest<GroupProductVm> {
    public int GroupShopListId { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
