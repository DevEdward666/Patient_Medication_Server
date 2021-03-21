using System;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WEB_API.Dependencies;
using WEB_API.Providers;

namespace OAuth_Custom_DB
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }


        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the application for OAuth based flow
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new AccessTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(60*60*60),
                RefreshTokenProvider = new RefreshTokenProvider(),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true,
            };



            // Enable the application to use bearer tokens to authenticate users
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieSecure = CookieSecureOption.Always
            });

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerTokens(OAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
