using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CopyOneProduct;
public class CopyOneProductCommandHandler : IRequestHandler<CopyOneProductCommand> {
    private readonly IProductService _productService;
    private readonly IDateTimeService _dateTimeService;
    private readonly IApplicationDbContext _context;

    public CopyOneProductCommandHandler(IProductService productService,
        IDateTimeService dateTimeService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _dateTimeService = dateTimeService;
        _context = context;
    }
    public async Task<Unit> Handle(CopyOneProductCommand request, 
        CancellationToken cancellationToken) {

        var productDb = await _productService.FindByIdAsync(request.Id);

        var newProduct = new Product {
            Name = productDb.Name,
            Quantity = productDb.Quantity,
            Volume = productDb.Volume,
            VolumeUnit = productDb.VolumeUnit,
            Weight = productDb.Weight,
            WeightUnit = productDb.WeightUnit,
            ShoppingListId = request.ParentShoppingListId,
            CreatedDate = _dateTimeService.Now,
            IsChecked = false,
            IsCopied = true
        };

        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
