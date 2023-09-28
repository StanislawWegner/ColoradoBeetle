using ColoradoBeetle.Application.GroupShopLists.Queries;

namespace ColoradoBeetle.Application.GroupProducts.Queries; 
public class GroupProductVm {
    public IEnumerable<GroupProductDto> GroupProductsDtos { get; set; }
    public GroupShopListDto GroupShopListDto { get; set; }
    public int GroupId { get; set; }
}
