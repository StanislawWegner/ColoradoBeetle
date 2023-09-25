using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand> {
    private readonly IProductService _productService;
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IProductService productService,
        IApplicationDbContext context)
    {
        _productService = productService;
        _context = context;
    }

    public async Task<Unit> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken) {

        var productDb = await _productService.FindByIdAsync(request.Id, request.UserId);

        _context.Products.Remove(productDb);
        await _context.SaveChangesAsync();

        return Unit.Value;

    }
}
