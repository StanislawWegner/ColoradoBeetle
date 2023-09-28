using ColoradoBeetle.Domain.Enums;

namespace ColoradoBeetle.Domain.Entities; 
public class GroupProduct {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? Quantity { get; set; }
    public int? Volume { get; set; }
    public VolumeUnit? VolumeUnit { get; set; }
    public int? Weight { get; set; }
    public WeightUnit? WeightUnit { get; set; }
    public bool IsChecked { get; set; }
    public bool IsCopied { get; set; }
    public bool OnStock { get; set; } = true;


    public GroupShopList GroupShopList { get; set; }
    public int GroupShopListId { get; set; }

    public ApplicationUser ApplicatioUser { get; set; }
    public string UserId { get; set; }

    public Group Group { get; set; }
    public int GroupId { get; set; }
}
