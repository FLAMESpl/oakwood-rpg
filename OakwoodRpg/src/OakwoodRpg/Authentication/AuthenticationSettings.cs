namespace OakwoodRpg.Authentication;

public record AuthenticationSettings
{
    public FacebookAuthenticationSettings? Facebook { get; set; }
}
