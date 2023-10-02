using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupProducts.Commands.EditGroupProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetEditGroupProduct;
public class GetEditGroupProductQueryHandler : IRequestHandler<GetEditGroupProductQuery,
    EditGroupProductCommand> {
    private readonly IGroupProductService _groupProductService;
    private readonly IApplicationDbContext _context;

    public GetEditGroupProductQueryHandler(IGroupProductService groupProductService,
        IApplicationDbContext context)
    {
        _groupProductService = groupProductService;
        _context = context;
    }
    public async Task<EditGroupProductCommand> Handle(GetEditGroupProductQuery request, 
        CancellationToken cancellationToken) {



        var isUserInGroup = await _groupProductService
            .IsUserInGroup(request.GroupId, request.UserId);

        if (isUserInGroup) {

            var groupProductDb = await _context.GroupProducts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return new EditGroupProductCommand {
                Id = groupProductDb.Id,
                Name = groupProductDb.Name,
                Quantity = groupProductDb.Quantity,
                Volume = groupProductDb.Volume,
                VolumeUnit = groupProductDb.VolumeUnit,
                Weight = groupProductDb.Weight,
                WeightUnit = groupProductDb.WeightUnit,
                GroupId = groupProductDb.GroupId,
                UserId = request.UserId
            };
        }
        else {
            throw new NotImplementedException();
        }

    }
}
