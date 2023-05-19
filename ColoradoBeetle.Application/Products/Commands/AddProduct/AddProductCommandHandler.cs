using MediatR;

namespace ColoradoBeetle.Application.Products.Commands.AddProduct;
public class AddProductCommandHandler : IRequestHandler<AddProductCommand> {
    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken) {

        return Unit.Value;
    }

}
