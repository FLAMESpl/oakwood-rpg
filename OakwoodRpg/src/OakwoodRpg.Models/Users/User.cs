using OakwoodRpg.Models.Audt;

namespace OakwoodRpg.Models.Users;

internal record User(
    ulong Id,
    AuditMetadata? AuditMetadata,
    string? ExternalId,
    string DisplayName,
    string? AvatarUrl,
    IdentityProvider? IdentityProvider);
