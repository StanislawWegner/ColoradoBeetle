using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = ColoradoBeetle.Domain.Entities.File;

namespace ColoradoBeetle.Infrastructure.Persistence.Configurations;

class FileConfiguration : IEntityTypeConfiguration<File> {
    public void Configure(EntityTypeBuilder<File> builder) {
        builder.ToTable("Files");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.Description)
            .IsRequired();
    }
}