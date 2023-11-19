using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;
public class GroupProductConfiguration : IEntityTypeConfiguration<GroupProduct> {
    public void Configure(EntityTypeBuilder<GroupProduct> builder) {

        builder.ToTable("GroupProducts");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.OnStock)
            .HasDefaultValue(true);

        builder.Property(x => x.GroupShopListId)
            .IsRequired();

        builder.Property(x => x.GroupId)
            .IsRequired();

        builder.HasOne(x => x.GroupShopList)
            .WithMany(x => x.GroupProducts)
            .HasForeignKey(x => x.GroupShopListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ApplicatioUser)
            .WithMany(x => x.GroupProducts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.GroupProducts)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.EditedByUser)
            .WithMany(x => x.EditedGroupProducts)
            .HasForeignKey(x => x.EditedByUserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
