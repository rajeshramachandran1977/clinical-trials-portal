using Anju.Navigate.Utilities;
using Anju.Navigate.Utilities.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Anju.Navigate.DataAccess;
using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace Anju.Navigation
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

               
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterConfigValues();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => { opts.ResourcesPath = "App_GlobalResources"; })
                .AddDataAnnotationsLocalization();
            services.AddRazorPages();
            services.AddKendo();
            services.AddMemoryCache();
            services.AddSession(s => { s.IdleTimeout = TimeSpan.FromMinutes(30); });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("fr")
                    };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }



        /// <summary>
        /// Configuration Values
        /// </summary>
        private void RegisterConfigValues()
        {
            CommonRepository cmnRep = new CommonRepository();

            ConfigValues.ServiceURL = Configuration["ServiceURL:Source"];
            ConfigValues.APIURL = Configuration["APIURL:Source"];
            ConfigValues.DBConnection = Configuration["Development:SqlConnectionString"];
            ConfigValues.DBType = Configuration["DatabaseType:Source"];
            ConfigValues.PasswordRecoverySubject = Configuration["Subject:Value"];
            ConfigValues.Host = Configuration["Host:Value"];
            ConfigValues.FromMail = Configuration["FromMail:Value"];
            ConfigValues.Port = Convert.ToInt32(Configuration["SMTPPort:Value"]);
            ConfigValues.IsSSL = Configuration["Key:Value"].Equals("true", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            ConfigValues.LinkSession = Convert.ToInt32(Configuration["LinkSession:Value"]);
            ConfigValues.DocumentsUploadFolderPath = Configuration["DocumentUploadFolderPath:path"];
            ConfigValues.appName = cmnRep.GetCompanyName();
            ConfigValues.ipV4Address = GetLocalIPv4Address();
            ConfigValues.ipV6Address = GetLocalIPv6Address();
            ConfigValues.version = GetAssemblyVersion();
            ConfigValues.Year = DateTime.Now.Year.ToString();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            RegisterNLog(loggerFactory);

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Documents")),
                RequestPath = "/Documents"
            });

            app.UseHttpsRedirection();
            var supportedCultures = new[]
           {
                 new CultureInfo("en-US"),
                 new CultureInfo("fr"),
             };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseSession();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseHttpContext();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }


        /// <summary>
        /// Register Log
        /// </summary>
        /// <param name="loggerFactory"></param>
        private void RegisterNLog(ILoggerFactory loggerFactory)
        {
            if (string.IsNullOrEmpty(ConfigValues.DBConnection))
                throw new SystemException("Sql Connection is not established ");
            GlobalDiagnosticsContext.Set("connectionString", ConfigValues.DBConnection);

            loggerFactory.AddNLog();

            LogManager.Configuration.Variables["microservicename"] = "Anju.Navigate.UI";
        }


        /// <summary>
        /// Get Local IP Address ipv4 
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPv4Address()
        {
            var clientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            return clientIP.ToString();
        }


        /// <summary>
        /// Get Local IP Address ipv6
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIPv6Address()
        {
            var clientIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            return clientIP.ToString();
        }


        public string GetAssemblyVersion()
        {
            return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
