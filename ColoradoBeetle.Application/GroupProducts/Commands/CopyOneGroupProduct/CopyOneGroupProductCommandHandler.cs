using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Commands.CopyOneGroupProduct;
public class CopyOneGroupProductCommandHandler : IRequestHandler<CopyOneGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;
    private readonly IDateTimeService _dateTimeService;

    public CopyOneGroupProductCommandHandler(IApplicationDbContext context,
        IGroupProductService groupProductService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _groupProductService = groupProductService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(CopyOneGroupProductCommand request, 
        CancellationToken cancellationToken) {

        var groupProductDb = await _groupProductService.FindGroupProductByIdAsync(request.Id);

        var isUserInGroup = await _groupProductService.IsUserInGroupAsync(groupProductDb.GroupId,
            request.UserId);

        if (isUserInGroup) {

            var newProduct = new GroupProduct {
                Name = groupProductDb.Name,
                Quantity = groupProductDb.Quantity,
                Volume = groupProductDb.Volume,
                VolumeUnit = groupProductDb.VolumeUnit,
                Weight = groupProductDb.Weight,
                WeightUnit = groupProductDb.WeightUnit,
                GroupShopListId = request.PrntId,
                UserId = request.UserId,
                GroupId = groupProductDb.GroupId,
                CreatedDate = _dateTimeService.Now,
                IsCopied = true
            };

            await _context.GroupProducts
                .AddAsync(newProduct);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        else {
            throw new NotImplementedException();
        }

    }
}
