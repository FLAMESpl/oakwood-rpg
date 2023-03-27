using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ScopedAttribute : ServiceAttribute
{
    public ScopedAttribute(Type? serviceType = null) : base(ServiceLifetime.Scoped, serviceType)
    {
    }
}
