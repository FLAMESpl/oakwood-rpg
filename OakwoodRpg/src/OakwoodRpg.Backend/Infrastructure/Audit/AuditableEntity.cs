using NodaTime;
using OakwoodRpg.Messaging;
using OakwoodRpg.Models.Audt;

namespace OakwoodRpg.Backend.Infrastructure.Audit;

internal abstract class AuditableEntity
{
    protected AuditableEntity()
    {
    }

    public ulong? CreatedByUserId { get; protected set; }
    public ulong? LastUpdatedByUserId { get; protected set; }
    public Guid? CreatedCorrelationId { get; protected set; }
    public Guid? LastUpdatedCorrelationId { get; protected set; }
    public Instant? CreatedTimestamp { get; protected set; }
    public Instant? LastUpdatedTimestamp { get; protected set; }

    public void Created(Instant now, MessageContext context)
    {
        CreatedByUserId = context.UserId;
        CreatedCorrelationId = context.CorrelationId;
        CreatedTimestamp = now;
    }

    public void Updated(Instant now, MessageContext context)
    {
        LastUpdatedByUserId = context.UserId;
        LastUpdatedCorrelationId = context.CorrelationId;
        LastUpdatedTimestamp = now;
    }

    public AuditMetadata GetMetadataModel() => new(
        CreatedByUserId: CreatedByUserId,
        LastUpdatedByUserId: LastUpdatedByUserId,
        CreatedCorrelationId: CreatedCorrelationId,
        LastUpdatedCorrelationId: LastUpdatedCorrelationId,
        CreatedTimestamp: CreatedTimestamp,
        LastUpdatedTimestamp: LastUpdatedTimestamp);
}
