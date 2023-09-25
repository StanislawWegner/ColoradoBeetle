using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Extensions;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Application.ShoppingLists.Extensions;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace ColoradoBeetle.Infrastructure.Services;
public class ProductService : IProductService {
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public ProductService(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public IEnumerable<Product> GetProducts(int shoppingListId, string currentUserId) {
        
        return _context
            .Products
            .AsNoTracking()
            .Where(x => x.ShoppingListId == shoppingListId && x.UserId == currentUserId);
    }
    public IEnumerable<ProductDto> GetProductsInListDtos(int shoppingListId,
        string currentUserId) {

        return _context
            .Products
            .AsNoTracking()
            .Where(x => x.ShoppingListId == shoppingListId && x.UserId == currentUserId)
            .Select(x => x.ToDto());
        
    }

    public async Task<Product>  FindByIdAsync(int productId, string currentUserId) {

        return await _context
            .Products
            .FirstOrDefaultAsync(x => x.Id == productId && x.UserId == currentUserId);

    }

    public async Task ValidateProductName(string name, int shoppingListId, 
        string currentUserId) {
        
        var productDb = await _context
        .Products
        .AsNoTracking()
        .Where(x => x.ShoppingListId == shoppingListId && x.UserId == currentUserId)
        .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

        if (productDb != null) {
            throw new ValidationException( new List<ValidationFailure>{
                new ValidationFailure("Name", $"Produkt o nazwie '{name}' już istnieje.")
            });
        }
    }
}
