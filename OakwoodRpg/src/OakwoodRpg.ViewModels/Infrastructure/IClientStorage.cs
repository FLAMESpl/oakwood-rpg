namespace OakwoodRpg.ViewModels.Infrastructure;

public interface IClientStorage
{
    ValueTask<T> Get<T>(string key, CancellationToken cancellationToken = default);
    ValueTask Set<T>(string key, T value, CancellationToken cancellationToken = default);
    ValueTask Remove(string key, CancellationToken cancellationToken = default);
}
