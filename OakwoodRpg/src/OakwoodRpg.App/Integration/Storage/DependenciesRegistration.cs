using Blazored.LocalStorage;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg.App.Integration.Storage;

internal class DependenciesRegistration : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddBlazoredLocalStorage();
    }
}
