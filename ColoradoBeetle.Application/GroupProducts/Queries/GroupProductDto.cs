using ColoradoBeetle.Domain.Enums;

namespace ColoradoBeetle.Application.GroupProducts.Queries; 
public class GroupProductDto {
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
    public bool OnStock { get; set; }

    public string UserEmail { get; set; }


}
