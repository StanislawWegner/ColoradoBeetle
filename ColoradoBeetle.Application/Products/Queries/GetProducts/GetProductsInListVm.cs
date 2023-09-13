using ColoradoBeetle.Application.ShoppingLists.Queries.GetShoppingLists;

namespace ColoradoBeetle.Application.Products.Queries.GetProducts; 
public class GetProductsInListVm {
    public IEnumerable<ProductDto> ProductDtoList { get; set; }
    public ShoppingListDto ShoppingListDto { get; set; }
}
