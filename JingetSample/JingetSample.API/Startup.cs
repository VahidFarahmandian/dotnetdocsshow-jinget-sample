using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Jinget.ApplicationCore.WebApi.Extensions.StartupExtensions.Service.Models;
using Jinget.ApplicationCore.WebApi.Extensions.StartupExtensions.Application;
using Jinget.ApplicationCore.WebApi.Extensions.StartupExtensions.Service;
using JingetSample.CommandHandlers.Services;
using JingetSample.DomainServices;
using JingetSample.Infrastructure.Data.EF;
using JingetSample.QueryHandlers.Queries.UserQueries;

namespace JingetSample.API
{
    public class Startup
    {
        protected static IConfiguration Configuration { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            var commandsDiscovery = new List<DISettingModel>
            {
                new DISettingModel
                {
                    AssemblySampleMember = typeof(UserDomainService),
                    DiscoveryNamespace = nameof(Jinget.Domain.Services)
                },
                new DISettingModel
                {
                    AssemblySampleMember = typeof(UserCommandHandler),
                    DiscoveryNamespace = nameof(JingetSample.CommandHandlers.Services)
                }
            };

            var queriesDiscovery = new List<Type>
            {
                typeof(AllUsersQueryHandlers)
            };

            var dbContextSetting = new DbContextSettingModel
            {
                ConnectionString = Configuration["ConnectionStrings:JingetConnection"]
            };

            services
                .ConfigureJinget<JingetSampleContext, PrincipalManager>(
                    commandsDiscovery,
                    dbContextSetting,
                    queriesDiscovery)
                .AddSingleton(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.ConfigureMiddlewares()
                .UseRouting()
                .UseEndpoints(routes =>
                {
                    routes.MapControllerRoute("routes", "api/{controller}/{action}/{id?}");
                    routes.MapControllers();
                });
        }
    }
}
