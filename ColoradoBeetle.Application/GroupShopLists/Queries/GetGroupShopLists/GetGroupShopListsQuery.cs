using ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopLists;
using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopList; 
public class GetGroupShopListsQuery : IRequest<GroupShopListsVm> {
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
