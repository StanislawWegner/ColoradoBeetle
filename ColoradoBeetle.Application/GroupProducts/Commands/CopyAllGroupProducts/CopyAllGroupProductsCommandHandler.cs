using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CopyAllGroupProducts;
public class CopyAllGroupProductsCommandHandler : IRequestHandler<CopyAllGroupProductsCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;
    private readonly IDateTimeService _dateTimeService;

    public CopyAllGroupProductsCommandHandler(IApplicationDbContext context,
        IGroupProductService groupProductService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _groupProductService = groupProductService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(CopyAllGroupProductsCommand request,
        CancellationToken cancellationToken) {

        var isUserInGroup = await _groupProductService
            .IsUserInGroupAsync(request.GroupId, request.UserId);

        if (isUserInGroup) {
            
            var groupProductsDb = _context.GroupProducts
            .AsNoTracking()
            .Where(x => x.GroupShopListId == request.ChildId)
            .Select(x => new GroupProduct {
                Name = x.Name,
                Quantity = x.Quantity,
                Volume = x.Volume,
                VolumeUnit = x.VolumeUnit,
                Weight = x.Weight,
                WeightUnit = x.WeightUnit,
                CreatedDate = _dateTimeService.Now,
                IsCopied = true,
                GroupShopListId = request.PrntId,
                UserId = request.UserId,
                GroupId = request.GroupId
            });

            await _context.GroupProducts
                .AddRangeAsync(groupProductsDb);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        else {
            throw new NotImplementedException();
        }
    }
}
