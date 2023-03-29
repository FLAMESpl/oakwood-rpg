using OakwoodRpg.Authentication;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg.App.Bootstrapping;

public class AuthenticationBootstrap : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationSettings>(configuration.GetSection("Authentication").Bind);
    }
}
