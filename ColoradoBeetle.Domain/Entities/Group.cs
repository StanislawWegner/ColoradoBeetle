namespace ColoradoBeetle.Domain.Entities; 
public class Group {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ApplicationUser> ApplicationUsers { get; set; } 
        = new HashSet<ApplicationUser>();

    public ICollection<GroupShopList> GroupShopLists { get; set; }
        = new HashSet<GroupShopList>();

    public ICollection<GroupProduct> GroupProducts { get; set; }
        = new HashSet<GroupProduct>();


}
