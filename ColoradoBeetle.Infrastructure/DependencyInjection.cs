  using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Domain.Entities;
using ColoradoBeetle.Infrastructure.Persistence;
using ColoradoBeetle.Infrastructure.Services;
using ColoradoBeetle.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GymManager.Infrastructure.Encryption;
using ColoradoBeetle.Infrastructure.Encryption;

namespace ColoradoBeetle.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration) {


        var encryptionService = new EncryptionService(
            new KeyInfo(configuration.GetValue<string>("EncriptionKeys:KeyString"),
                        configuration.GetValue<string>("EncriptionKeys:IVString")));

        services.AddSingleton<IEncryptionService>(encryptionService);

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


        var connectionString = encryptionService
            .Decrypt(configuration.GetConnectionString("DefaultConnection"));

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddIdentity<ApplicationUser, IdentityRole>(options => {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password = new PasswordOptions {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireNonAlphanumeric = true
            };
        }).AddErrorDescriber<LocalizedIdentityErrorDescriber>()
          .AddRoleManager<RoleManager<IdentityRole>>()
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultUI()
          .AddDefaultTokenProviders();

        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IRoleManagerService, RoleManagerService>();
        services.AddScoped<IUserRoleManagerService, UserRoleManagerService>();
        services.AddSingleton<IAppSettingsService, AppSettingsService>();
        services.AddSingleton<IEmail, Email>();
        services.AddHttpContextAccessor();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IShoppingListService, ShoppingListService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IGroupShopListService, GroupShopListService>();
        services.AddScoped<IGroupProductService, GroupProductService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app,
        IApplicationDbContext context, IAppSettingsService appSettingsService, IEmail email) {

        appSettingsService.Update(context).GetAwaiter().GetResult();
        email.Update(appSettingsService).GetAwaiter().GetResult();

        return app;
    }
}
