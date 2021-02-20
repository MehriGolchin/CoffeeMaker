using CafeeMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeeMaker.Infrastructure.Repositories {

    public class CafeeMakerDbContext : DbContext {

        public CafeeMakerDbContext(DbContextOptions<CafeeMakerDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>(builder => {
                builder.ToTable("employee");

                builder.Property(e => e.EmployeeId).HasColumnName("employee_id").IsRequired();
                builder.Property(e => e.FirstName).HasColumnName("firstname");
                builder.Property(e => e.LastName).HasColumnName("lastname");

                builder.HasKey(e => e.EmployeeId);
            });

            modelBuilder.Entity<Employee>().HasData(
                new {EmployeeId = 1, FirstName = "AA1", LastName = "BB1"},
                new {EmployeeId = 2, FirstName = "AA2", LastName = "BB2"}
            );
        }

    }

}