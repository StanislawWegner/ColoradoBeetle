namespace ColoradoBeetle.Domain.Entities; 
public class GroupShopList {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }


    public Group Group { get; set; }
    public int GroupId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string UserId { get; set; }

    public ApplicationUser EditedByUser { get; set; }
    public string EditedByUserId { get; set; }

    public ICollection<GroupProduct> GroupProducts { get; set; } 
        = new HashSet<GroupProduct>();

}
