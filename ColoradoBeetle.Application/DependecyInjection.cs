using ColoradoBeetle.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ColoradoBeetle.Application; 
public static class DependecyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));


        return services;
    }

}