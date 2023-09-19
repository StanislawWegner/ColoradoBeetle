using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;
public class GroupConfiguration : IEntityTypeConfiguration<Group> {
    public void Configure(EntityTypeBuilder<Group> builder) {

        builder.ToTable("Groups");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(g => g.ApplicationUsers)
            .WithMany(a => a.Groups)
            .UsingEntity<ApplicationUserGroup>(
                a => a.HasOne(aug => aug.User)
                    .WithMany()
                    .HasForeignKey(aug => aug.UserId)
                    .OnDelete(DeleteBehavior.Restrict),
                a => a.HasOne(aug => aug.Group)
                    .WithMany()
                    .HasForeignKey(aug => aug.GroupId)
                    .OnDelete(DeleteBehavior.Restrict),

                aug => {
                    aug.HasKey(x => new { x.UserId, x.GroupId });
                    aug.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                });
        
    }
}
