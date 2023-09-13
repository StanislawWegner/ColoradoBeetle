using ColoradoBeetle.Application.Products.Queries.GetProducts;
using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;
using System.Net.Http.Headers;

namespace ColoradoBeetle.Application.Products.Queries.GetChildProducts; 
public class GetChildProductsVm {
    public IEnumerable<ProductDto> ProductDtoList { get; set; }
    public ShoppingListDto ParentShoppingListDto { get; set; }
    public ShoppingListDto ChildShoppingListDto { get; set; }
}
