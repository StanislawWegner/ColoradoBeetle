using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Infrastructure.Persistence;
using ColoradoBeetle.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ColoradoBeetle.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration) {

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

        services.AddSingleton<IAppSettingsService, AppSettingsService>();
        services.AddSingleton<IEmail, Email>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app,
        IApplicationDbContext context, IAppSettingsService appSettingsService, IEmail email) {

        appSettingsService.Update(context).GetAwaiter().GetResult();
        email.Update(appSettingsService).GetAwaiter().GetResult();

        return app;
    }
}
