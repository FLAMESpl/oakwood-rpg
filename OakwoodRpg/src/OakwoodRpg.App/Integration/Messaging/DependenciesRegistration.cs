using OakwoodRpg.Bootstrapping;
using OakwoodRpg.Messaging;

namespace OakwoodRpg.App.Integration.Messaging;

internal class DependenciesRegistration : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageBus, InMemoryHandlerDispatchingMessageBus>();
    }
}
