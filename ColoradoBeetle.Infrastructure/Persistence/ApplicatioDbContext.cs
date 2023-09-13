using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using ColoradoBeetle.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using File = ColoradoBeetle.Domain.Entities.File;

namespace ColoradoBeetle.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IApplicationDbContext {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SettingsPosition> SettingsPositions { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.SeedLanguage();
        modelBuilder.SeedSettings();
        modelBuilder.SeedSettingsPosition();
        modelBuilder.SeedRoles();

        base.OnModelCreating(modelBuilder);
    }

}
