using ColoradoBeetle.Application.GroupShopLists.Queries;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.GroupShopLists.Extensions; 
public static class GroupShopListExtensions {

    public static GroupShopListDto ToDto(this GroupShopList groupShopList) {

        return new GroupShopListDto {
            Id = groupShopList.Id,
            Name = groupShopList.Name,
            CreatedDate = groupShopList.CreatedDate,
            UserEmail = groupShopList.ApplicationUser?.Email
        };
    }
}
