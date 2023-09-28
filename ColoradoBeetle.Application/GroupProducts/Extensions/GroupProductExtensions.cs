using ColoradoBeetle.Application.GroupProducts.Queries;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.GroupProducts.Extensions; 
public static class GroupProductExtensions {
    public static GroupProductDto ToDto(this GroupProduct groupProduct) {

        if (groupProduct == null)
            return null;

        return new GroupProductDto {
            Id = groupProduct.Id,
            Name = groupProduct.Name,
            CreatedDate = groupProduct.CreatedDate,
            Quantity = groupProduct.Quantity,
            Volume = groupProduct.Volume,
            VolumeUnit = groupProduct.VolumeUnit,
            Weight = groupProduct.Weight,
            WeightUnit = groupProduct.WeightUnit,
            IsChecked = groupProduct.IsChecked,
            IsCopied = groupProduct.IsCopied,
            OnStock = groupProduct.OnStock,
            UserEmail = groupProduct.ApplicatioUser?.Email
        };
    }
}
