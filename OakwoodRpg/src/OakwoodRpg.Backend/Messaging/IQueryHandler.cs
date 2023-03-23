using OakwoodRpg.Messaging;

namespace OakwoodRpg.Backend.Messaging;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> Handle(TQuery query, MessageContext messageContext, CancellationToken cancellationToken);
}
