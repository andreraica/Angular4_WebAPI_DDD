using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Owin.Security.Infrastructure;
using System.Collections.Concurrent;


//https://help.salesforce.com/apex/HTViewHelpDoc?id=remoteaccess_oauth_refresh_token_flow.htm&language=en
//https://github.com/IdentityModel/Thinktecture.IdentityModel

namespace AndreRaicaRegister.Services.WebAPI
{
    public partial class Startup
    {
        public static IDataProtectionProvider DataProtectionProvider { get; set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);


            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            // Configure the application for OAuth based flow
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider("self"),
                AuthorizeEndpointPath = new PathString("/Account/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(30),
                AllowInsecureHttp = true
                //RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };
            
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }

    }

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            //ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            //if (user == null)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect.");
            //    return;
            //}

            if (context.UserName != "admin" || context.Password != "admin" )
            {
                context.Rejected();
                return;
            }


            ClaimsIdentity oAuthIdentity = new ClaimsIdentity("UserAuthType", "NameType", "RoleType"); //await user.GenerateUserIdentityAsync(userManager);
            ClaimsIdentity cookiesIdentity = new ClaimsIdentity("UserAuthType", "NameType", "RoleType"); //await user.GenerateUserIdentityAsync(userManager);

            var properties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { "as:client_id", context.ClientId }
                });

            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);

            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);

            //EXTREMAMENTE NECESSÁRIO, pois quando se trata do middleware do OWIN, o CORS não atende
            //if (!context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Para segurança em produção
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "http://localhost:1099" });
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            //return Task.FromResult<object>(null);

            string id, secret;
            if (context.TryGetFormCredentials(out id, out secret))
            {
                if (secret == "secret")
                {
                    context.OwinContext.Set<string>("as:client_id", id);
                    context.Validated();
                }
            }

            //necessário senão reclamava de não ter retorno o método, não sei o que significa o codigo abaixo
            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}