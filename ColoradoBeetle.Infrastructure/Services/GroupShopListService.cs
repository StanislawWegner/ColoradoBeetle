using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ColoradoBeetle.Infrastructure.Services;
public class GroupShopListService : IGroupShopListService {
    private readonly IApplicationDbContext _context;

    public GroupShopListService(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<GroupShopList> FindGroupShopListById(int id) { 

        return await _context.GroupShopLists
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> IsUserInGroup(int groupId, string userId) {
        
        var groupDb = await _context.Groups
            .Include(x => x.ApplicationUsers)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == groupId);

        return groupDb.ApplicationUsers.Any(x => x.Id == userId);
    }

    public async Task ValidateGroupShopListName(string shopListName, int groupId) {

        var groupShopListDb = await _context.GroupShopLists
            .AsNoTracking()
            .Where(x => x.GroupId == groupId)
            .FirstOrDefaultAsync(x => x.Name.ToUpper() == shopListName.ToUpper());

        if (groupShopListDb != null) {
            throw new ValidationException(new List<ValidationFailure>
                { new ValidationFailure ("Name",
                    $"Lista o nazwie '{shopListName}' już istnieje.")});
        }
    }
}
