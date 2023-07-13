using ColoradoBeetle.Application.Products.Commands.AddProduct;

namespace ColoradoBeetle.Application.Common.Interfaces; 
public interface IProductService {

    Task CreateAsync(AddProductCommand command);
}
