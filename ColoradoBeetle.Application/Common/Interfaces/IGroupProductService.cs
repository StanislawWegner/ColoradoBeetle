namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IGroupProductService {
    Task ValidateGroupShopListName(string groupProductName, int groupShopListId);
    Task<bool> IsUserInGroup(int groupId, string userId);
}
