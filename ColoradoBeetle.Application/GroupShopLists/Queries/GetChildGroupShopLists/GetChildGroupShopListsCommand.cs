using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetChildGroupShopLists; 
public class GetChildGroupShopListsCommand : IRequest<ChildGroupShopListsVm>{
    public int PrntId { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }
    
}
