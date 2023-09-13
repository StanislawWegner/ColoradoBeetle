using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Products.Commands.EditProduct; 
public class EditProductCommandHandler : IRequestHandler<EditProductCommand> {
    private readonly IProductService _productService;
    private readonly IApplicationDbContext _context;

    public EditProductCommandHandler(IProductService productService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _context = context;
    }
    public async Task<Unit> Handle(EditProductCommand request, 
        CancellationToken cancellationToken) {

        var productDb = await _productService.FindByIdAsync(request.Id);

        if (productDb.Name != request.Name)
            await _productService.ValidateProductName(request.Name, request.ShoppingListId);

        productDb.Name = request.Name;
        productDb.Quantity = request.Quantity;
        productDb.Volume = request.Volume;
        productDb.VolumeUnit = request.VolumeUnit;
        productDb.Weight = request.Weight;
        productDb.WeightUnit = request.WeightUnit;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
