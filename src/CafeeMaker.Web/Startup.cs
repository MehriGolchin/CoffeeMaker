using System.IO;
using System.Threading.Tasks;
using System.Web;
using CafeeMaker.Application;
using CafeeMaker.Domain;
using CafeeMaker.Infrastructure;
using CafeeMaker.Infrastructure.Repositories;
using CafeeMaker.Service;
using CafeeMaker.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Routing;
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
                .AddScoped<IPreferenceService, PreferenceService>()
                .AddScoped<ICoffeeMachine, DummyCoffeeMachine>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/account/login";
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
                
                spa.ApplicationBuilder.MapWhen(
                    context => context.User.Identity != null && !context.User.Identity.IsAuthenticated,
                    ab => {
                        ab.Run( (ctx) => {
                            ctx.Response.Redirect($"/account/login?returnUrl={HttpUtility.UrlEncode(ctx.Request.Path)}");
                            return Task.CompletedTask;
                        });
                    }
                );

                if (env.IsDevelopment()) {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

    }

}