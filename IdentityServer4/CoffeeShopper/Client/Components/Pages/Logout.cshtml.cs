using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Client.Components.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IConfiguration config;

        public LogoutModel(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return SignOut(
                new AuthenticationProperties
                {
                    RedirectUri = config["applicationUrl"]
                },
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
