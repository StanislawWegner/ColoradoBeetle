using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CheckGroupProduct;
public class CheckGroupProductCommandHandler : IRequestHandler<CheckGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;

    public CheckGroupProductCommandHandler(IApplicationDbContext context,
        IGroupProductService groupProductService)
    {
        _context = context;
        _groupProductService = groupProductService;
    }
    public async Task<Unit> Handle(CheckGroupProductCommand request, 
        CancellationToken cancellationToken) {

        var groupProductDb = await _groupProductService.FindGroupProductByIdAsync(request.Id);

        groupProductDb.IsChecked = request.IsChecked;

        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
