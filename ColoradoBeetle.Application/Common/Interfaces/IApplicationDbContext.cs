using ColoradoBeetle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using File = ColoradoBeetle.Domain.Entities.File;

namespace ColoradoBeetle.Application.Common.Interfaces;
public interface IApplicationDbContext : IDisposable {

    DbSet<Address> Addresses { get; set; }
    DbSet<Client> Clients { get; set; }
    DbSet<SettingsPosition> SettingsPositions { get; set; }
    DbSet<Settings> Settings { get; set; }
    DbSet<File> Files { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<ApplicationUser> Users { get; set; }
    DbSet<ShoppingList> ShoppingLists { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
    DbSet<GroupShopList> GroupShopLists { get; set; }
    DbSet<GroupProduct> GroupProducts { get; set; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
