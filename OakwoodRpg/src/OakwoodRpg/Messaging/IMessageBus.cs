namespace OakwoodRpg.Messaging;

public interface IMessageBus
{
    Task Send(ICommand command, MessageContext context, CancellationToken cancellationToken = default);
    Task<TResult> Send<TResult>(IQuery<TResult> query, MessageContext context, CancellationToken cancellationToken = default);
}
