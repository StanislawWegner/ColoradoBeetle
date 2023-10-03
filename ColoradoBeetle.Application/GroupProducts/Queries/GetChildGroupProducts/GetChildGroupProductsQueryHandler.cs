using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Application.GroupProducts.Extensions;
using ColoradoBeetle.Application.GroupShopLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetChildGroupProducts;
public class GetChildGroupProductsQueryHandler : IRequestHandler<GetChildGroupProductsQuery,
    GetChildGroupProductsVm> {
    private readonly IGroupProductService _groupProductService;
    private readonly IGroupShopListService _groupShopListService;
    private readonly IApplicationDbContext _context;

    public GetChildGroupProductsQueryHandler(IGroupProductService groupProductService,
        IGroupShopListService groupShopListService,
        IApplicationDbContext context)
    {
        _groupProductService = groupProductService;
        _groupShopListService = groupShopListService;
        _context = context;
    }
    public async Task<GetChildGroupProductsVm> Handle(GetChildGroupProductsQuery request, 
        CancellationToken cancellationToken) {

        var isUserInGroup = await _groupProductService
            .IsUserInGroupAsync(request.GroupId, request.UserId);

        if (isUserInGroup) {

            var prntGroupShopListDto = (await _groupShopListService
            .FindGroupShopListByIdAsync(request.PrntId))
            .ToDto();

            var childGroupShopListDto = (await _groupShopListService
            .FindGroupShopListByIdAsync(request.ChildId))
            .ToDto();

            var groupProductsDtos = _context.GroupProducts
                .Include(x => x.ApplicatioUser)
                .AsNoTracking()
                .Where(x => x.GroupShopListId == request.ChildId)
                .Select(x => x.ToDto());

            return new GetChildGroupProductsVm { 
                PrntGroupShopListDto = prntGroupShopListDto,
                ChildGroupShopListDto = childGroupShopListDto,
                GroupId = request.GroupId,
                GroupProductDtos = groupProductsDtos
            };
        }
        else {
            throw new NotImplementedException();
        }
    }
}
