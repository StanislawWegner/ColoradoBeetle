namespace ColoradoBeetle.Domain.Entities; 
public class ApplicationUserGroup {
    public ApplicationUser User { get; set; }
    public string UserId { get; set; }
    public Group Group { get; set; }
    public int GroupId { get; set; }

    public DateTime CreatedDate { get; set; }
}
