using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.AddMultiGroupProduct;
public class AddMultiGroupProductCommandHandler : IRequestHandler<AddMultiGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IGroupProductService _groupProductService;

    public AddMultiGroupProductCommandHandler(IApplicationDbContext context, 
        IDateTimeService dateTimeService,
        IGroupProductService groupProductService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _groupProductService = groupProductService;
    }
    public async Task<Unit> Handle(AddMultiGroupProductCommand request, 
        CancellationToken cancellationToken) {

        var isUserInGroup = await _groupProductService.IsUserInGroupAsync(request.GroupId,
            request.UserId);

        if (isUserInGroup) {
            var newGroupProducts = request.MultiGroupProductNames
            .Split("\r\n")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => new GroupProduct {
                Name = x.Trim(),
                CreatedDate = _dateTimeService.Now,
                GroupShopListId = request.GroupShopListId,
                UserId = request.UserId,
                GroupId = request.GroupId
            });

            await _context.GroupProducts.AddRangeAsync(newGroupProducts);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        else {
            throw new NotImplementedException();
        }
        
    }
}
