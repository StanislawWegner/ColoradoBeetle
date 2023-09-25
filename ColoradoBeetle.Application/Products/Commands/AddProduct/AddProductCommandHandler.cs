using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ColoradoBeetle.Application.Products.Commands.AddProduct;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand> {
    private readonly IProductService _productService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IApplicationDbContext _context;

    public AddProductCommandHandler(IProductService productService,
        IDateTimeService dateTimeService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _dateTimeService = dateTimeService;
        _context = context;
    }
    public async Task<Unit> Handle(AddProductCommand request,
    CancellationToken cancellationToken) {

        await _productService.ValidateProductName(
            request.Name, 
            request.ShoppingListId,
            request.UserId);

        var newProduct = new Product {
            Name = request.Name,
            Quantity = request.Quantity,
            Volume = request.Volume,
            VolumeUnit = request.VolumeUnit,
            Weight = request.Weight,
            WeightUnit = request.WeightUnit,
            ShoppingListId = request.ShoppingListId,
            UserId = request.UserId,
            CreatedDate = _dateTimeService.Now
            
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }

}
