namespace ColoradoBeetle.Domain.Entities; 
public class Group {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ApplicationUser> ApplicationUsers { get; set; } 
        = new HashSet<ApplicationUser>();

    
}
