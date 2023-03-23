using OakwoodRpg.Backend.Messaging;
using OakwoodRpg.Messaging;

namespace OakwoodRpg.App.BackendIntegration.Messaging;

internal class InMemoryHandlerDispatchingMessageBus : IMessageBus
{
    private readonly IServiceScopeFactory serviceScopeFactory;

    public InMemoryHandlerDispatchingMessageBus(IServiceScopeFactory serviceScopeFactory)
    {
        this.serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Send(
        ICommand command, 
        MessageContext messageContext, 
        CancellationToken cancellationToken = default)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
        await handlerType
            .GetMethod(nameof(ICommandHandler<ICommand>.Handle))!
            .InvokeWithTargetInvocationExceptionUnpacking(
                scope.ServiceProvider.GetRequiredService(handlerType),
                new object[] { command, messageContext, cancellationToken });
    }

    public async Task<TResult> Send<TResult>(
        IQuery<TResult> query, 
        MessageContext messageContext, 
        CancellationToken cancellationToken = default)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        return await handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.Handle))!
            .InvokeWithTargetInvocationExceptionUnpacking<TResult>(
                scope.ServiceProvider.GetRequiredService(handlerType),
                new object[] { query, messageContext, cancellationToken });
    }
}
