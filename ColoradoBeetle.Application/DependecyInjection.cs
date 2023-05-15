using Microsoft.Extensions.DependencyInjection;

namespace ColoradoBeetle.Application; 
public static class DependecyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        return services;
    }

}