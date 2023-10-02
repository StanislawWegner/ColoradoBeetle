using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IGroupProductService {
    Task ValidateGroupProductName(string groupProductName, int groupShopListId);
    Task<bool> IsUserInGroup(int groupId, string userId);
    Task<GroupProduct> FindGroupProductById(int id);
}
