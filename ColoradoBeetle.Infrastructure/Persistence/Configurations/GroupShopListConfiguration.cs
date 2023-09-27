using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;
public class GroupShopListConfiguration : IEntityTypeConfiguration<GroupShopList> {
    public void Configure(EntityTypeBuilder<GroupShopList> builder) {

        builder.ToTable("GroupShopLists");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.GroupId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.Group)
            .WithMany(x => x.GroupShopLists)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ApplicationUser)
            .WithMany(x => x.GroupShopLists)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);



    }
}
