using ERP.Reports.Api.Interfaces.Repository;
using ERP.Reports.Api.Interfaces.Services;
using ERP.Reports.Api.Models.Core;
using ERP.Reports.Api.Repository;
using ERP.Reports.Api.Services.OAuths;
using ERP.Reports.Api.Services.Reports;
using ERP.Reports.Api.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Net.Http;
using Unity;
using Unity.Microsoft.DependencyInjection;
using Unity.Resolution;

namespace ERP.Reports.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            ServiceCollection services = new ServiceCollection();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(WebApiApplication).Assembly))
                    .AddRepositories()
                    .AddCustomServices();

            //services.AddTransient<IDocumentationProvider>(s => new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));
            services.BuildServiceProvider(container);

        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReportRepository, ReportRepository>();
            return services;
        }
        private static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IOauthServerApiClient>(s =>
            {
                var clientFactory = s.GetService<IHttpClientFactory>();
                var oauthServerConfig = s.GetService<OauthServerConfig>();
                return new OauthServerApiClient(oauthServerConfig.OauthServer, clientFactory.CreateClient());
            });



            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IUserService, UserService>();



            services.AddSingleton<ConnectionString>(s => new ConnectionString(ConfigurationManager.ConnectionStrings[ConnectionString.NAME].ConnectionString));

            services.AddSingleton<OauthServerConfig>(s => new OauthServerConfig()
            {
                OauthServer = ConfigurationManager.AppSettings.Get(OauthServerConfig.OAUTHSERVER_KEY),
                Service = ConfigurationManager.AppSettings.Get(OauthServerConfig.SERVICE_KEY),
            });
            services.AddSingleton<OauthJwtConfig>(s => new OauthJwtConfig
            {
                Audience = ConfigurationManager.AppSettings.Get(OauthJwtConfig.OAUTHJWT_AUDIENCE),
                Issuer = ConfigurationManager.AppSettings.Get(OauthJwtConfig.OAUTHJWT_ISSUER),
                Key = ConfigurationManager.AppSettings.Get(OauthJwtConfig.OAUTHJWT_KEY)
            });
            return services;
        }

        public static T Resolve<T>(params ResolverOverride[] overrides)
        {
            return Container.Resolve<T>();
        }
    }
}