using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ColoradoBeetle.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
        return services;
    }

    public static IApplicationBuilder UseInfrstructure(this IApplicationBuilder app) {
        return app;
    }
}
