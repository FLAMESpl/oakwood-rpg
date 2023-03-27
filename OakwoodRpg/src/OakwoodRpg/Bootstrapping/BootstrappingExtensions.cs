using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OakwoodRpg.Bootstrapping;

public static class BootstrappingExtensions
{
    public static IServiceCollection BootstrapAssemblyRepresentedBy<TRepresentative>(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var assemblyTypes = typeof(TRepresentative).Assembly.GetTypes();

        RegisterDeclaredServices(assemblyTypes, services);
        RunDependenciesRegistrations(assemblyTypes, services, configuration);

        return services;
    }

    private static void RegisterDeclaredServices(IEnumerable<Type> assemblyTypes, IServiceCollection services)
    {
        assemblyTypes
            .Select(type => (Type: type, Attribute: type.GetCustomAttribute<ServiceAttribute>()))
            .Where(x => x.Attribute is not null)
            .ForEach(x => x.Attribute!.Register(x.Type, services));
    }

    private static void RunDependenciesRegistrations(
        IEnumerable<Type> assemblyTypes, 
        IServiceCollection services, 
        IConfiguration configuration)
    {
        var registrationInterfaceType = typeof(IDependenciesRegistration);

        assemblyTypes
            .Where(t => t.IsAssignableTo(registrationInterfaceType) && !t.IsAbstract)
            .Select(t => (IDependenciesRegistration)(Activator.CreateInstance(t) ??
                throw new InvalidOperationException($"Cannot bootstrap instance of '{t}'.")))
            .ForEach(x => x.Register(services, configuration));
    }
}
