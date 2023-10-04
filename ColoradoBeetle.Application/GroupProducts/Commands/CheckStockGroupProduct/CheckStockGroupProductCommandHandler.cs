using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CheckStockGroupProduct;
public class CheckStockGroupProductCommandHandler : IRequestHandler<CheckStockGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;

    public CheckStockGroupProductCommandHandler(IApplicationDbContext context, 
        IGroupProductService groupProductService)
    {
        _context = context;
        _groupProductService = groupProductService;
    }
    public async Task<Unit> Handle(CheckStockGroupProductCommand request,
    CancellationToken cancellationToken) {

        var groupProductDb = await _groupProductService.FindGroupProductByIdAsync(request.Id);

        groupProductDb.OnStock = request.OnStock;

        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
