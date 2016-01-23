using flipyserverService.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(flipyserverService.Startup))]

namespace flipyserverService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*app.CreatePerOwinContext(MobileServiceContext.Create);
            app.CreatePerOwinContext<AccountManager>(AccountManager.Create);*/
            ConfigureMobileApp(app);
            //ConfigureCustomAuth(app);
        }

        /*public static void ConfigureCustomAuth(IAppBuilder appBuilder) {
            OAuthAuthorizationServerOptions oAuthServerOptions =
                new OAuthAuthorizationServerOptions() {
                    TokenEndpointPath = new PathString("/oauth/token"),
                    Provider = new CustomLoginProvider(),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    AccessTokenFormat = new CustomZumoTokenFormat(),
                };

            // OAuth Configuration
            appBuilder.UseOAuthAuthorizationServer(oAuthServerOptions);
        }*/
    }
}