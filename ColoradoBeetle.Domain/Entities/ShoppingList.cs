namespace ColoradoBeetle.Domain.Entities; 
public class ShoppingList {

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }


    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    
}
