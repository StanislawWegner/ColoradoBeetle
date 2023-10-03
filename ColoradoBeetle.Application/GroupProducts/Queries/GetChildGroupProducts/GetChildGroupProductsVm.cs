using ColoradoBeetle.Application.GroupShopLists.Queries;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetChildGroupProducts; 
public class GetChildGroupProductsVm {
    public GroupShopListDto PrntGroupShopListDto { get; set; }
    public GroupShopListDto ChildGroupShopListDto { get; set; }
    public int GroupId { get; set; }
    public IEnumerable<GroupProductDto> GroupProductDtos { get; set; }
}
