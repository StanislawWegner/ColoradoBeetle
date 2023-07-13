using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Commands.AddProduct;
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
    public async Task CreateAsync(AddProductCommand command) {

        await ValidateProductName(command.Name);

        var newProduct = new Product {
            Name = command.Name,
            Quantity = command.Quantity,
            Volume = command.Volume,
            VolumeUnit = command.VolumeUnit,
            Weight = command.Weight,
            WeightUnit = command.WeightUnit,
            ShoppingListId = command.ShoppingListId,
            CreatedDate = _dateTimeService.Now
        };

        await _context.Products.AddAsync(newProduct);

        await _context.SaveChangesAsync();  
    }

    private async Task ValidateProductName(string name) {
        
        var productDb = await _context
        .Products
        .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

        if (productDb != null) {
            throw new ValidationException( new List<ValidationFailure>{
                new ValidationFailure("Name", $"Product o nazwie {name} już istnieje.")
            });
        }
    }
}
