using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Common.Interfaces {
    public interface IGroupShopListService {
        Task ValidateGroupShopListName(string shoppingListName, int groupId);
        Task<GroupShopList> FindGroupShopListById(int id);
        Task<bool> IsUserInGroup(int groupId, string userId);

    }
}
