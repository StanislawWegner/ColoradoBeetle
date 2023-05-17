using ColoradoBeetle.Application.Common.Interfaces;
using ColoradoBeetle.Infrastructure.Persistence;
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

        return services;
    }

    public static IApplicationBuilder UseInfrstructure(this IApplicationBuilder app) {
        return app;
    }
}
