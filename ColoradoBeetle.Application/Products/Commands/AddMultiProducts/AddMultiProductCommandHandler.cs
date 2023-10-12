using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.AddMultiProducts {
    public class AddMultiProductCommandHandler : IRequestHandler<AddMultiProductCommand> {
        private readonly IApplicationDbContext _context;
        private readonly IDateTimeService _dateTimeService;

        public AddMultiProductCommandHandler(IApplicationDbContext context,
            IDateTimeService dateTimeService)
        {
            _context = context;
            _dateTimeService = dateTimeService;
        }
        public async Task<Unit> Handle(AddMultiProductCommand request, 
            CancellationToken cancellationToken) {

            var newProducts = request.MultiProductsNames
                .Split("\r\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x =>
                    new Product {
                        Name = x.Trim(),
                        CreatedDate = _dateTimeService.Now,
                        ShoppingListId = request.ShoppingListId,
                        UserId = request.UserId
                    }); 


            await _context.Products.AddRangeAsync(newProducts);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
