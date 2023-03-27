using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TransientAttribute : ServiceAttribute
{
    public TransientAttribute(Type? serviceType = null) : base(ServiceLifetime.Transient, serviceType)
    {
    }
}
