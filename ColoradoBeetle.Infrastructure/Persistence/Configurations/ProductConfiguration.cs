using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;

class ProductConfiguration : IEntityTypeConfiguration<Product> {
    public void Configure(EntityTypeBuilder<Product> builder) {
        builder.ToTable("Products");

        builder.Property(x => x.UserId)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}