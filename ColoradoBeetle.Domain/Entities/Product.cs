using ColoradoBeetle.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColoradoBeetle.Domain.Entities;
public class Product {
    
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

    public int ShoppingListId { get; set; }
    public ShoppingList ShoppingList { get; set; }

}
