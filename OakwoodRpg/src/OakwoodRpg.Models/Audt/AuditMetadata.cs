using NodaTime;

namespace OakwoodRpg.Models.Audt;

public record AuditMetadata(
    ulong? CreatedByUserId,
    ulong? LastUpdatedByUserId,
    Guid? CreatedCorrelationId,
    Guid? LastUpdatedCorrelationId,
    Instant? CreatedTimestamp,
    Instant? LastUpdatedTimestamp);
