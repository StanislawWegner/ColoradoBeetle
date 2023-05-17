namespace ColoradoBeetle.Domain.Entities;
public class ApplicationUser {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegisterDateTime { get; set; }
    public bool IsDeleted { get; set; }

    public Address Address { get; set; }
    public Client Client { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    
}
