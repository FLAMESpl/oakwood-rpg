using OakwoodRpg.Backend;
using OakwoodRpg.Bootstrapping;
using OakwoodRpg.ViewModels.Index;

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

            builder.Services.AddHttpClient().AddScoped<HttpClient>();
            builder.Services.AddHttpContextAccessor().AddScoped<HttpContextAccessor>();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.BootstrapAssemblyRepresentedBy<Program>(builder.Configuration);
            builder.Services.BootstrapAssemblyRepresentedBy<IDependenciesRegistration>(builder.Configuration);
            builder.Services.BootstrapAssemblyRepresentedBy<IndexViewModel>(builder.Configuration);
            builder.Services.BootstrapAssemblyRepresentedBy<InfrastructureRegistration>(builder.Configuration);
            
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions { Secure = CookieSecurePolicy.Always });
            app.UseAuthentication();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }
    }
}