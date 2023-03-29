using OakwoodRpg.Backend;
using OakwoodRpg.Bootstrapping;

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

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}