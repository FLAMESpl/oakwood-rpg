using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OakwoodRpg.Bootstrapping;

public interface IDependenciesRegistration
{
    void Register(IServiceCollection services, IConfiguration configuration);
}
