namespace OakwoodRpg.Messaging;

public record MessageContext(Guid CorrelationId, ulong? UserId)
{
    public static MessageContext Create(ulong? userId = null) => new(Guid.NewGuid(), userId);
}
