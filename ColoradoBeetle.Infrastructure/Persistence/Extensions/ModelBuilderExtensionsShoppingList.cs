using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsShoppingList {
    public static void SeedShoppingLists(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<ShoppingList>().HasData(
            new ShoppingList {
                Id = 1,
                Name = "Lista zakupów nr: 1",
                CreatedDate = new DateTime(2023, 06, 28, 16, 00, 00),
                UserId = "f9967bf4-cc0e-4dea-a1f2-97600e64adc6"
            },
            new ShoppingList {
                Id = 2,
                Name = "Lista zakupów nr: 2",
                CreatedDate = new DateTime(2023, 06, 28, 16, 00, 05),
                UserId = "f9967bf4-cc0e-4dea-a1f2-97600e64adc6"
            },
            new ShoppingList {
                Id = 3,
                Name = "Lista zakupów nr: 3",
                CreatedDate = new DateTime(2023, 06, 28, 16, 00, 10),
                UserId = "f9967bf4-cc0e-4dea-a1f2-97600e64adc6"
            }
            );

            

    }
}
