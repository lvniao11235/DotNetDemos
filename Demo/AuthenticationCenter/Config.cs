using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityModel;
using System.Security.Claims;

namespace AuthenticationCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "My Api")
            };
        }

        public static IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client
            {
                ClientId = "mvc_implicit",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.Implicit,                //简化模式
                RequireConsent = false,     //Consent是授权页面，这里我们不进行授权

                RedirectUris = { "http://localhost:1798/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:1798/signout-callback-oidc" },

                //授权后可以访问的用户信息（OpenId Connect Scope）与Api（OAuth2.0 Scope）
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "api"
                },

                //允许返回Access Token
                AllowAccessTokensViaBrowser = true
            }
        };

        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static List<TestUser> GetTestUsers() => new List<TestUser>
        {
            new TestUser()
            {
                SubjectId="1",
                Username="test",
                Password="123456",
                Claims = new List<Claim> {
                    new Claim(JwtClaimTypes.Email, "test@163.com")
                }
            }
        };
    }
}
