using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

public static class BootstrappingExtensions
{
    public static IServiceCollection BootstrapAssemblyRepresentedBy<TRepresentative>(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var registrationInterfaceType = typeof(IDependenciesRegistration);

        typeof(TRepresentative)
            .Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(registrationInterfaceType) && !t.IsAbstract)
            .Select(t => (IDependenciesRegistration)(Activator.CreateInstance(t) ??
                throw new InvalidOperationException($"Cannot bootstrap instance of '{t}'.")))
            .ForEach(x => x.Register(services, configuration));

        return services;
    }
}
