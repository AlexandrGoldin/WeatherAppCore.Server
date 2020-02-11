using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataL;
using BuissnesL;
using BuissnesL.Interfaces;
using BuissnesL.Implementations;
using Hangfire;
using PresentationL.HangFireWeatherRequestService;

namespace WeatherAppCore.Server.Api
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        { 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WeatherContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DataL")));
          
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection")));

            services.AddHangfireServer();
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // partial class Startup_Transient.cs
            SetUpDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHangfireDashboard();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
          
            app.UseMvc(routes =>
            {
                // :(
                //routes.MapRoute("api", "api/get", new { controller = "WeatherApi", action = "GetJsResponse" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=HangFireRequest}/{action=Index}/{id?}");
            });
        }
    }
}
