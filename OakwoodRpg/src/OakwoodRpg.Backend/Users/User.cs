using NodaTime;
using OakwoodRpg.Backend.Infrastructure.Audit;
using OakwoodRpg.Messaging;
using OakwoodRpg.Models.Users;

namespace OakwoodRpg.Backend.Users;

internal class User : AuditableEntity
{
    private User() { }

    public User(
        Instant now,
        MessageContext messageContext,
        ulong id,
        string externalId,
        string displayName,
        string? avatar,
        IdentityProvider identityProvider)
    {
        Id = id;
        ExternalId = externalId;
        DisplayName = displayName;
        Avatar = avatar;
        IdentityProvider = identityProvider;

        Created(now, messageContext);
    }

    public ulong Id { get; private set; }
    public string ExternalId { get; private set; } = string.Empty;
    public string DisplayName { get; private set; } = string.Empty;
    public string? Avatar { get; private set; }
    public IdentityProvider IdentityProvider { get; private set; }


}
