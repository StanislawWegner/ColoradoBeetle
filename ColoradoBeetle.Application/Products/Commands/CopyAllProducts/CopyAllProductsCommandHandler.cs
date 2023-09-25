using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CopyAllProducts;
public class CopyAllProductsCommandHandler : IRequestHandler<CopyAllProductsCommand> {
    private readonly IProductService _productService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IApplicationDbContext _context;

    public CopyAllProductsCommandHandler(IProductService productService,
        IDateTimeService dateTimeService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _dateTimeService = dateTimeService;
        _context = context;
    }
    public async Task<Unit> Handle(CopyAllProductsCommand request, 
        CancellationToken cancellationToken) {

        var childListProducts = _productService
            .GetProducts(request.ChildShoppingListId, request.UserId);
            
         var parentListProducts = childListProducts.Select(x => new Product {
            Name = x.Name,
            Quantity = x.Quantity,
            Volume = x.Volume,
            VolumeUnit = x.VolumeUnit,
            Weight = x.Weight,
            WeightUnit = x.WeightUnit,
            ShoppingListId = request.ParentShoppingListId,
            UserId = request.UserId,
            CreatedDate = _dateTimeService.Now,
            IsChecked = false,
            IsCopied = true
        });

        await _context.Products.AddRangeAsync(parentListProducts);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
