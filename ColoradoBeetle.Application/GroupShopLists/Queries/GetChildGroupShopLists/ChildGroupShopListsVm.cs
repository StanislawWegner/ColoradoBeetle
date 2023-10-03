namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetChildGroupShopLists; 
public class ChildGroupShopListsVm {
    public int PrntId { get; set; }
    public int GroupId { get; set; }
    public IEnumerable<GroupShopListDto> ChildGroupShopListsDtos { get; set; }
}
