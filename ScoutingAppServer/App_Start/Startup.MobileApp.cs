﻿using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using ScoutingServer.Models;

namespace ScoutingServer {
    public partial class Startup {
        public static void ConfigureMobileApp(IAppBuilder app) {
            HttpConfiguration config = new HttpConfiguration();

            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            config.MapHttpAttributeRoutes();

            Database.SetInitializer(new ScoutingAppInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if(string.IsNullOrEmpty(settings.HostName)) {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class ScoutingAppInitializer : CreateDatabaseIfNotExists<MobileServiceContext> {
        protected override void Seed(MobileServiceContext context) {
            base.Seed(context);
        }
    }
}

