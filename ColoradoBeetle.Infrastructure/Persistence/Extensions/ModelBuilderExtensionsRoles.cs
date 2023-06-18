using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ColoradoBeetle.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsRoles {
    public static void SeedRoles(this ModelBuilder modelBuilder) {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = "DA0D03EA-3DB5-48E1-A88F-7ED520A9289A",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "D7D71FD0-C6D1-455C-86E8-ED861B169F46"
            },

            new IdentityRole {
                Id = "F5502C99-1E28-4025-AB7B-6D99CE8EE4A3",
                Name = "Klient",
                NormalizedName = "KLIENT",
                ConcurrencyStamp = "85AA5510-5124-4B37-B63A-382656367B02"
            }
            );

    }
}
