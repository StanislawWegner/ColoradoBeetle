using ColoradoBeetle.Application.Groups.Queries.GetGroups;
using ColoradoBeetle.Application.Groups.Queries.GetUsersInGroup;

namespace ColoradoBeetle.Application.GroupShopLists.Queries.GetGroupShopLists; 
public class GroupShopListsVm {
    public GroupDto GroupDto { get; set; }
    public IEnumerable<GroupShopListDto> GroupShopListsDtos { get; set; }
}
