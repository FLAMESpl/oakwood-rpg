using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg;

internal class SharedServicesRegistration : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IClock>(SystemClock.Instance);
    }
}
