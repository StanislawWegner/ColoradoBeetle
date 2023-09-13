using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.CheckProduct;
public class CheckProductCommandHandler : IRequestHandler<CheckProductCommand> {
    private readonly IProductService _productService;
    private readonly IApplicationDbContext _context;

    public CheckProductCommandHandler(IProductService productService,
        IApplicationDbContext context) {
        _productService = productService;
        _context = context;
    }
    public async Task<Unit> Handle(CheckProductCommand request, 
        CancellationToken cancellationToken) {

        var productDB = await _productService.FindByIdAsync(request.Id);

        productDB.IsChecked = request.IsChecked;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
