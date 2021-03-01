using System.IO;
using CafeeMaker.Application;
using CafeeMaker.Domain;
using CafeeMaker.Infrastructure.Repositories;
using CafeeMaker.Service;
using CafeeMaker.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace CafeeMaker.Web {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            
            services.AddDbContext<CafeeMakerDbContext>(builder => 
                builder
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .UseNpgsql(Configuration.GetConnectionString("Default")));

            services.AddHttpContextAccessor();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<IDrinkRepository, DrinkRepository>()
                .AddScoped<IDrinkService, DrinkService>()
                .AddScoped<IPreferenceRepository, PreferenceRepository>()
                .AddScoped<IPreferenceService, PreferenceService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/login";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new CompositeFileProvider(
                    new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "ClientApp/node_modules/bootstrap")),
                    new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot")))
            });
            
            app.UseSpaStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

    }

}