using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeeltle.Infrastructure.Persistence.Configurations;
class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList> {
    public void Configure(EntityTypeBuilder<ShoppingList> builder) {
        builder.ToTable("ShoppingLists");

        builder.Property(x => x.UserId)
            .IsRequired();

        builder
           .HasOne(x => x.User)
           .WithMany(x => x.ShoppingLists)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);

        
    }
}
