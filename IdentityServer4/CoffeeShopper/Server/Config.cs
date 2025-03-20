using Duende.IdentityServer.Models;
using ApiResource = Duende.IdentityServer.Models.ApiResource;
using ApiScope = Duende.IdentityServer.Models.ApiScope;
using IdentityResource = Duende.IdentityServer.Models.IdentityResource;

namespace Server
{
    //STATIC DATA THAT WILL BE INSERTED INTO IDENTITY SERVER DATABASE TABLES
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string>{"role"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("CoffeeAPI.read"),
                new ApiScope("CoffeeAPI.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
              new ApiResource("CoffeeAPI")
              {
                 Scopes = new List<string> { "CoffeeAPI.read", "CoffeeAPI.write" },
                 ApiSecrets = new List < Secret> { new Secret("ScopeSecret".Sha256())},
                 UserClaims = { "role" }
        }
    };

        public static IEnumerable<Client> Clients =>
        new[]
        {
            //m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                AllowedScopes = { "CoffeeAPI.read", "CoffeeAPI.write" }
            },

            // interactive cliwnt using code flow + plkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string> { "https://localhost:5444/authentication/login-callback" },
                FrontChannelLogoutUri = "https://localhost:5444/authentication/logout",
                PostLogoutRedirectUris = { "https://localhost:5444/authentication/logout-callback" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "CoffeeAPI.read" },
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false
            }
        };
    }
}
