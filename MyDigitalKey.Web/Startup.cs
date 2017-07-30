using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Persistence.InMemory;
using MyDigitalKey.Services;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Web.AutoMapper;
using System;
using MyDigitalKey.Web.Configurations;

namespace MyDigitalKey.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton(MappingLoader.Load());

            // Adds services required for using options.
            services.AddOptions();

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<AppSettings>(Configuration);

            services.AddMvc();

            // Add application services.
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDigitalKeyService, DigitalKeyService>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<ILockService, LockService>();

            // Add repositories
            services.AddSingleton<IRepository<User>, MemoryRepository<User>>();
            services.AddSingleton<IRepository<DigitalKey>, MemoryRepository<DigitalKey>>();
            services.AddSingleton<IRepository<Authorization>, MemoryRepository<Authorization>>();
            services.AddSingleton<IRepository<Lock>, MemoryRepository<Lock>>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
              
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=AuthorizationView}/{action=Index}/{id?}");
            });
        }
    }
}