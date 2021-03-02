using System.Linq;
using CafeeMaker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeeMaker.Web.Test.Integrations {

    public class CustomWebApplicationFactory : WebApplicationFactory<Startup> {

        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            builder.ConfigureServices(services => {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<CafeeMakerDbContext>));

                services.Remove(descriptor);
                
                services.AddDbContext<CafeeMakerDbContext>(optionsBuilder => 
                    optionsBuilder.UseInMemoryDatabase("test_db"));
                
                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<CafeeMakerDbContext>();

                db.Database.EnsureCreated();
            });
        }

    }

}