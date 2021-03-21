using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_API.Dependencies;

[assembly: OwinStartup(typeof(OAuth_Custom_DB.Startup))]
namespace OAuth_Custom_DB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                //map.UseCors(CorsOptions.AllowAll);
                map.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
                {
                    Provider = new QueryStringOAuthBearerProvider()
                });

                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true,
                    Resolver = GlobalHost.DependencyResolver,
                };
                map.RunSignalR(hubConfiguration);
            });
            ConfigureAuth(app);
        }
    }
}