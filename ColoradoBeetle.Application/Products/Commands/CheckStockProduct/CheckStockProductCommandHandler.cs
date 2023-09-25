using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CheckStockProduct;
public class CheckStockProductCommandHandler : IRequestHandler<CheckStockProductCommand> {
    private readonly IProductService _productService;
    private readonly IApplicationDbContext _context;

    public CheckStockProductCommandHandler(IProductService productService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _context = context;
    }

    public async Task<Unit> Handle(CheckStockProductCommand request,
        CancellationToken cancellationToken) {

        var productDb = await _productService.FindByIdAsync(request.Id, request.UserId);

        productDb.OnStock = request.OnStock;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
