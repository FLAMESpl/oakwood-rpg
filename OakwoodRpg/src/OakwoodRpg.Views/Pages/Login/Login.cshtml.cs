using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OakwoodRpg.Authentication;
using System.Security.Claims;

namespace OakwoodRpg.Views.Pages.Login;

[AllowAnonymous]
public class LoginModel : PageModel
{
    public IActionResult OnGetAsync(string? returnUrl = null)
    {
        return new ChallengeResult(
            AuthenticationSchemas.Facebook,
            new AuthenticationProperties
            {
                RedirectUri = Url.Page(
                pageName: "./Login",
                pageHandler: "Callback",
                values: new { returnUrl }),
            });
    }

    public async Task<IActionResult> OnGetCallbackAsync(
        string? returnUrl = null, string? remoteError = null)
    {
        var googleUser = User.Identities.FirstOrDefault();

        if (googleUser?.IsAuthenticated is true)
        {
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(googleUser),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = Request.Host.Value
                });
        }

        return LocalRedirect("/");
    }
}
