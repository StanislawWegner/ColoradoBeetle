namespace ColoradoBeetle.Application.Common.Interfaces {
    public interface IGroupShopListService {
        Task ValidateGroupShopListName(string shoppingListName, int groupId);

    }
}
