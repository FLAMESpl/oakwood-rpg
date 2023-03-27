using NodaTime;
using OakwoodRpg.Backend.Messaging;
using OakwoodRpg.Messaging;
using OakwoodRpg.Models.Users.Commands;

namespace OakwoodRpg.Backend.Users;

internal class UserCommandHandlers : ICommandHandler<CreateUser>
{
    private readonly IClock clock;
    private readonly OakwoodRpgContext dbContext;

    public UserCommandHandlers(IClock clock, OakwoodRpgContext dbContext)
    {
        this.clock = clock;
        this.dbContext = dbContext;
    }

    public async Task Handle(CreateUser command, MessageContext messageContext, CancellationToken cancellationToken)
    {
        var user = new User(
            now: clock.GetCurrentInstant(),
            messageContext: messageContext,
            id: default,
            externalId: command.ExternalId,
            displayName: command.DisplayName,
            avatar: command.Avatar,
            identityProvider: command.IdentityProvider);

        await dbContext.AddAsync(user, cancellationToken);
    }
}
