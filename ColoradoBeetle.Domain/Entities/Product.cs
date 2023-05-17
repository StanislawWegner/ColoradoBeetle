using ColoradoBeetle.Domain.Enums;

namespace ColoradoBeetle.Domain.Entities;
public class Product {
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Quantity { get; set; }
    public int Volume { get; set; }
    public VolumeUnit VolumeUnit { get; set; }
    public int Weight { get; set; }
    public WeightUnit WeightUnit { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

}
