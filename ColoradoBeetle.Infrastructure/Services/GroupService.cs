using ColoradoBeetle.Application.Common.Exceptions;
using ColoradoBeetle.Application.Common.Interfaces;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Services;
public class GroupService : IGroupService {
    private readonly IApplicationDbContext _context;

    public GroupService(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task ValidateGroupName(string name) {

        var groupDb = await _context.Groups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper()); 

        if (groupDb != null) {
            throw new ValidationException(new List<ValidationFailure> {
                new ValidationFailure("Name", $"Grupa o nazwie '{name}' już istnieje.")
            });
        }
    }
}
