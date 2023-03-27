using OakwoodRpg.Messaging;

namespace OakwoodRpg.Backend.Messaging;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, MessageContext messageContext, CancellationToken cancellationToken);
}
