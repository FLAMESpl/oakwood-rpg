using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg.Backend;

public class InfrastructureRegistration : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OakwoodRpgContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("OakwoodRpgContext")));
    }
}
