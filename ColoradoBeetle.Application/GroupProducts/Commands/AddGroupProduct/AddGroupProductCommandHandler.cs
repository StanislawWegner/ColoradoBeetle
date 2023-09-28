using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ColoradoBeetle.Application.GroupProducts.Commands.AddGroupProduct;
public class AddGroupProductCommandHandler : IRequestHandler<AddGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;
    private readonly IDateTimeService _dateTimeService;

    public AddGroupProductCommandHandler(IApplicationDbContext context,
        IGroupProductService groupProductService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _groupProductService = groupProductService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(AddGroupProductCommand request,
        CancellationToken cancellationToken) {

        if(await _groupProductService.IsUserInGroup(request.GroupId, request.UserId)) {

            await _groupProductService.ValidateGroupShopListName(request.Name,
                    request.GroupShopListId);


            var newGroupProduct = new GroupProduct {
                Name = request.Name,
                Quantity = request.Quantity,
                Volume = request.Volume,
                VolumeUnit = request.VolumeUnit,
                Weight = request.Weight,
                WeightUnit = request.WeightUnit,
                GroupShopListId = request.GroupShopListId,
                UserId = request.UserId,
                GroupId = request.GroupId,
                CreatedDate = _dateTimeService.Now

            };

            await _context.GroupProducts.AddAsync(newGroupProduct);

            await _context.SaveChangesAsync();

            return Unit.Value;

        }
        else {
            throw new NotImplementedException();
        }
    }
}
