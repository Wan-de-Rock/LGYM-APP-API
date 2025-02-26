using LgymApp.Api.Interfaces;
using LgymApp.Application.Interfaces;
using LgymApp.Domain.Helpers;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LgymApp.Api.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        var services = ReflectionHelper
            .GetAllTypesImplementingInterface<IService>();

        foreach (var service in services)
        {
            var descriptor = service switch 
            {
                ISingletonService => ServiceDescriptor.Singleton(service, service),
                IScopedService => ServiceDescriptor.Scoped(service, service),
                ITransientService => ServiceDescriptor.Transient(service, service),
                _ => ServiceDescriptor.Scoped(service, service)
            };
            
            serviceCollection.TryAdd(descriptor);
        }
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var endpointsServiceDescriptors = ReflectionHelper
            .GetAllTypesImplementingInterface<IEndpointDefinition>()
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpointDefinition), type))
            .ToArray();
        
        services.TryAddEnumerable(endpointsServiceDescriptors);
        
        return services;
    }
    
    public static IApplicationBuilder UseEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpointDefinitions = app.Services.GetServices<IEndpointDefinition>();
        IEndpointRouteBuilder routeBuilder = routeGroupBuilder is null ? app : routeGroupBuilder;
        
        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineEndpoints(routeBuilder);
        }

        return app;
    }
}