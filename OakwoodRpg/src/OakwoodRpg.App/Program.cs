using OakwoodRpg.Authentication;
using OakwoodRpg.Backend;
using OakwoodRpg.Bootstrapping;
using System.Linq.Expressions;

namespace OakwoodRpg.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddUserSecrets(typeof(Program).Assembly);
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Configuration.AddEnvironmentVariables();

            builder.Services.AddAuthentication(AuthenticationSchemas.Facebook).AddCookie().AddGoogle(options =>
            {
                var settings = GetAuthenticationSettings(builder.Configuration, x => x.Facebook);
                options.ClientId = settings.AppId;
                options.ClientSecret = settings.AppSecret;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.BootstrapAssemblyRepresentedBy<Program>(builder.Configuration);
            builder.Services.BootstrapAssemblyRepresentedBy<InfrastructureRegistration>(builder.Configuration);
            builder.Services.BootstrapAssemblyRepresentedBy<IDependenciesRegistration>(builder.Configuration);
            
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }

        private static T GetAuthenticationSettings<T>(
            IConfiguration configuration, 
            Expression<Func<AuthenticationSettings, T?>> selector)
        {
            const string sectionName = "Authentication";

            return selector.Compile().Invoke(configuration.GetRequiredSetting<AuthenticationSettings>(sectionName)) ??
                throw InvalidConfigurationException.GetForMissingValue(
                    $"{sectionName}:{((MemberExpression)selector.Body).Member.Name}");
        }
    }
}