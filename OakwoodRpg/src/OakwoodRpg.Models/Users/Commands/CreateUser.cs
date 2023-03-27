using OakwoodRpg.Messaging;

namespace OakwoodRpg.Models.Users.Commands;

public record CreateUser(
    string ExternalId, 
    string DisplayName,
    string? Avatar,
    IdentityProvider IdentityProvider) : ICommand;
