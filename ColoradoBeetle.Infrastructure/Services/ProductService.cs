using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Commands.AddProduct;
using ColoradoBeetle.Application.Products.Commands.EditProduct;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Services;
public class ProductService : IProductService {
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public ProductService(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public IEnumerable<Product> GetProducts(int shoppingListId) {
        
        return _context
            .Products
            .AsNoTracking()
            .Where(x => x.ShoppingListId == shoppingListId);
    }
    public IEnumerable<ProductDto> GetProductsInListDtos(int shoppingListId) {

        return _context
            .Products
            .AsNoTracking()
            .Where(x => x.ShoppingListId == shoppingListId)
            .Select(x => new ProductDto {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Volume = x.Volume,
                VolumeUnit = x.VolumeUnit,
                Weight = x.Weight,
                WeightUnit = x.WeightUnit,
                IsChecked = x.IsChecked,
                IsCopied = x.IsCopied,
                OnStock = x.OnStock
            });
    }

    public async Task<Product> FindByIdAsync(int productId) {

        return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == productId);
    }

    public async Task ValidateProductName(string name, int shoppingListId) {
        
        var productDb = await _context
        .Products
        .AsNoTracking()
        .Where(x => x.ShoppingListId == shoppingListId)
        .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

        if (productDb != null) {
            throw new ValidationException( new List<ValidationFailure>{
                new ValidationFailure("Name", $"Produkt o nazwie '{name}' już istnieje.")
            });
        }
    }
}
