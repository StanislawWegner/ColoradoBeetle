using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;

class ProductConfiguration : IEntityTypeConfiguration<Product> {
    public void Configure(EntityTypeBuilder<Product> builder) {
        builder.ToTable("Products");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ShoppingListId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.OnStock)
            .HasDefaultValue(true);

        builder
            .HasOne(x => x.ShoppingList)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ShoppingListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.ApplicationUser)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}