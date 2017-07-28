using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyDigitalKey.Domain.Interfaces;
using MyDigitalKey.Domain.Models;
using MyDigitalKey.Persistence.InMemory;
using MyDigitalKey.Services;
using MyDigitalKey.Services.Contracts.Interfaces;
using MyDigitalKey.Web.AutoMapper;

namespace MyDigitalKey.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton(MappingLoader.Load());
            services.AddMvc();

            // Add application services.
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDigitalKeyService, DigitalKeyService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            // Add repositories
            services.AddTransient<IRepository<User>, MemoryRepository<User>>();
            services.AddTransient<IRepository<DigitalKey>, MemoryRepository<DigitalKey>>();
            services.AddTransient<IRepository<Authorization>, MemoryRepository<Authorization>>();

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
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}