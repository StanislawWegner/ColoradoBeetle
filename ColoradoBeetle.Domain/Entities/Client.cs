namespace ColoradoBeetle.Domain.Entities;
public class Client {
    public int Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
