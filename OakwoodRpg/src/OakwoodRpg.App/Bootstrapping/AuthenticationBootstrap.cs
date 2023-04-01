using OakwoodRpg.Authentication;
using OakwoodRpg.Bootstrapping;

namespace OakwoodRpg.App.Bootstrapping;

public class AuthenticationBootstrap : IDependenciesRegistration
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(AuthenticationSchemas.Cookies).AddCookie(AuthenticationSchemas.Cookies);

        var authSettings = configuration.GetRequiredSetting<AuthenticationSettings>("Authentication");

        if (authSettings.Facebook is { } facebookSettings)
        {
            services.AddAuthentication().AddFacebook(AuthenticationSchemas.Facebook, options =>
            {
                options.ClientId = facebookSettings.AppId;
                options.ClientSecret = facebookSettings.AppSecret;
            });
        }

    }
}
