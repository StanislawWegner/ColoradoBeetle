using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Products.Extensions; 
public static class ProductExtension {

    public static ProductDto ToDto(this Product product) {

        if (product == null)
            return null;

        return new ProductDto {
            Id = product.Id,
            Name = product.Name,
            CreatedDate = product.CreatedDate,
            Quantity = product.Quantity,
            Volume = product.Volume,
            VolumeUnit = product.VolumeUnit,
            Weight = product.Weight,
            WeightUnit = product.WeightUnit,
            IsChecked = product.IsChecked,
            IsCopied = product.IsCopied,
            OnStock = product.OnStock,
            UserId = product.UserId
        };
    }
}
