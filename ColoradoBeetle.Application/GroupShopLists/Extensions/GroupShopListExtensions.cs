using ColoradoBeetle.Application.GroupShopLists.Queries;
using ColoradoBeetle.Application.Users.Extensions;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.GroupShopLists.Extensions; 
public static class GroupShopListExtensions {

    public static GroupShopListDto ToDto(this GroupShopList groupShopList) {

        if(groupShopList == null)
            return null;

        return new GroupShopListDto {
            Id = groupShopList.Id,
            Name = groupShopList.Name,
            CreatedDate = groupShopList.CreatedDate,
            UserEmail = groupShopList.ApplicationUser?.Email?.ToShortEmail()
        };
    }
}
