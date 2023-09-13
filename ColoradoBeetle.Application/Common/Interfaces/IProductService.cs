using ColoradoBeetle.Application.Products.Commands.AddProduct;
using ColoradoBeetle.Application.Products.Commands.EditProduct;
using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Domain.Entities;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IProductService {

    IEnumerable<Product> GetProducts(int shoppingListId);
    IEnumerable<ProductDto> GetProductsInListDtos(int shoppingListId);
    Task<Product> FindByIdAsync(int productId);
    Task ValidateProductName(string name, int shoppingListId);
}