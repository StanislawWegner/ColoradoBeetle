using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ColoradoBeetle.Infrastructure.Services;
public class GroupProductService : IGroupProductService {
    private readonly IApplicationDbContext _context;

    public GroupProductService(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task ValidateGroupProductName(string groupProductName, int groupShopListId) {

        var groupProductDb = await _context.GroupProducts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.GroupShopListId == groupShopListId
            && x.Name.ToUpper() == groupProductName.ToUpper());

            if (groupProductDb != null) {
                throw new ValidationException(new List<ValidationFailure>
                    { new ValidationFailure ("Name",
                    $"Produkt o nazwie '{groupProductName}' już istnieje.")});
            }
    }

    public async Task<bool> IsUserInGroup(int groupId, string userId) {
        
        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == groupId);

       return groupDb.ApplicationUsers.Any(x => x.Id == userId);
    }

    public async Task<GroupProduct> FindGroupProductById(int id) {
        
        return await _context.GroupProducts
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
