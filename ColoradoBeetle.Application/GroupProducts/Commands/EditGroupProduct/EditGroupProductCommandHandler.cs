using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Commands.EditGroupProduct;
public class EditGroupProductCommandHandler : IRequestHandler<EditGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;

    public EditGroupProductCommandHandler(IApplicationDbContext context, 
        IGroupProductService groupProductService)
    {
        _context = context;
        _groupProductService = groupProductService;
    }
    public async Task<Unit> Handle(EditGroupProductCommand request, 
        CancellationToken cancellationToken) {

        var isUserInGroup = await _groupProductService
            .IsUserInGroupAsync(request.GroupId, request.UserId);


        if (isUserInGroup) {
            var groupProductDb = await _context.GroupProducts
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (groupProductDb.Name != request.Name) {
                await _groupProductService.ValidateGroupProductName(request.Name,
                    groupProductDb.GroupShopListId);
            }

            groupProductDb.Name = request.Name;
            groupProductDb.Quantity = request.Quantity;
            groupProductDb.Volume = request.Volume;
            groupProductDb.VolumeUnit = request.VolumeUnit;
            groupProductDb.Weight = request.Weight;
            groupProductDb.WeightUnit = request.WeightUnit;
            groupProductDb.EditedByUserId = request.UserId;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        else {
            throw new NotImplementedException();
        }
        
    }
}
