using ColoradoBeetle.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace ColoradoBeetle.Application.GroupProducts.Commands.DeleteGroupProduct;
public class DeleteGroupProductCommandHandler : IRequestHandler<DeleteGroupProductCommand> {
    private readonly IApplicationDbContext _context;
    private readonly IGroupProductService _groupProductService;

    public DeleteGroupProductCommandHandler(IApplicationDbContext context, 
        IGroupProductService groupProductService)
    {
        _context = context;
        _groupProductService = groupProductService;
    }
    public async Task<Unit> Handle(DeleteGroupProductCommand request,
        CancellationToken cancellationToken) {

        var groupProductDb = await _groupProductService.FindGroupProductById(request.Id);

        var isUserInGroup = await _groupProductService.IsUserInGroup(groupProductDb.GroupId,
            request.UserId);

        if (isUserInGroup) {

            _context.GroupProducts.Remove(groupProductDb);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
        else {
            throw new NotImplementedException();
        }
    }
}
