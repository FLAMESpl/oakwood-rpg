using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ServiceAttribute : Attribute
{
    private readonly ServiceLifetime lifetime;
    private readonly Type? serviceType;

    public ServiceAttribute(ServiceLifetime lifetime, Type? serviceType = null)
    {
        this.lifetime = lifetime;
        this.serviceType = serviceType;
    }

    public void Register(Type implementationType, IServiceCollection services)
    {
        services.Add(new ServiceDescriptor(serviceType ?? implementationType, implementationType, lifetime));
    }
}
