using Blazored.LocalStorage;
using OakwoodRpg.Bootstrapping;
using OakwoodRpg.ViewModels.Infrastructure;

namespace OakwoodRpg.App.Integration.Storage;

[Scoped(typeof(IClientStorage))]
public class ClientStorage : IClientStorage
{
    private readonly ILocalStorageService service;

    public ClientStorage(ILocalStorageService service)
    {
        this.service = service;
    }

    public ValueTask<T> Get<T>(string key, CancellationToken cancellationToken = default) => 
        service.GetItemAsync<T>(key, cancellationToken);

    public ValueTask Remove(string key, CancellationToken cancellationToken = default) =>
        service.RemoveItemAsync(key, cancellationToken);

    public ValueTask Set<T>(string key, T value, CancellationToken cancellationToken = default) =>
        service.SetItemAsync(key, value, cancellationToken);
}
