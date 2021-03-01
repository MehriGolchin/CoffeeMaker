using System.Reflection.Emit;
using System.Text.Json.Serialization;
using CafeeMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CafeeMaker.Infrastructure.Repositories {

    public class CafeeMakerDbContext : DbContext {

        public CafeeMakerDbContext(DbContextOptions<CafeeMakerDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<DrinkIngredient> DrinkIngredients { get; set; }
        public DbSet<Preference> Preferences { get; set; }

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
            
            modelBuilder.Entity<Drink>(builder => {
                builder.ToTable("drink");

                builder.Property(d => d.DrinkId).HasColumnName("drink_id").IsRequired();
                builder.Property(d => d.Name).HasColumnName("drink_name");
                builder.Property(d => d.Image).HasColumnName("drink_image");

                builder.HasKey(d => d.DrinkId);
            });
            
            modelBuilder.Entity<Drink>().HasData(
                new {DrinkId = 1, Name = "Thé", Image = "/img/tea.png"},
                new {DrinkId = 2, Name = "Café", Image = "/img/coffee.png"},
                new {DrinkId = 3, Name = "Chocolat", Image = "/img/chocolate.png"}
            );
            
            modelBuilder.Entity<Ingredient>(builder => {
                builder.ToTable("ingredient");

                builder.Property(i => i.IngredientId).HasColumnName("ingredient_id").IsRequired();
                builder.Property(i => i.Name).HasColumnName("ingredient_name");

                builder.HasKey(i => i.IngredientId);
            });
            
            modelBuilder.Entity<Ingredient>().HasData(
                new {IngredientId = 1, Name = "Eau chaude"},
                new {IngredientId = 2, Name = "Thé noir"},
                new {IngredientId = 3, Name = "Sucre"},
                new {IngredientId = 4, Name = "Lait"},
                new {IngredientId = 5, Name = "Crème fouettée"},
                new {IngredientId = 6, Name = "Eau froide"},
                new {IngredientId = 7, Name = "Café"}
            );
            
            modelBuilder.Entity<DrinkIngredient>(builder => {
                builder.ToTable("drink_ingredient");

                builder.Property(di => di.DrinkIngredientId).HasColumnName("drink_ingredient_id").IsRequired();
                builder.Property(di => di.DrinkId).HasColumnName("drink_id").IsRequired();
                builder.Property(di => di.IngredientId).HasColumnName("ingredient_id");
                builder.Property(di => di.Amount).HasColumnName("amount");

                builder.HasKey(di => di.DrinkIngredientId);

                builder.HasOne(di => di.Ingredient);
            });
            
            modelBuilder.Entity<DrinkIngredient>().HasData(
                new {DrinkIngredientId = 1, DrinkId = 1, IngredientId = 1, Amount = 100},
                new {DrinkIngredientId = 2, DrinkId = 1, IngredientId = 2, Amount = 100},
                new {DrinkIngredientId = 3, DrinkId = 1, IngredientId = 3, Amount = 50},
                new {DrinkIngredientId = 4, DrinkId = 2, IngredientId = 7, Amount = 50},
                new {DrinkIngredientId = 5, DrinkId = 2, IngredientId = 4, Amount = 50},
                new {DrinkIngredientId = 6, DrinkId = 2, IngredientId = 1, Amount = 20}
            );

            modelBuilder.Entity<Drink>()
                .HasMany(d => d.Ingredients);

            modelBuilder.Entity<Preference>(builder => {
                builder.ToTable("preference");

                builder.Property(p => p.PreferenceId).HasColumnName("preference_id");
                builder.Property(p => p.EmployeeId).HasColumnName("employee_id");
                builder.Property(p => p.DrinkId).HasColumnName("drink_id");
                builder.Property(p => p.Value)
                    .HasConversion(
                        p => JsonConvert.SerializeObject(p),
                        json => JsonConvert.DeserializeObject<DrinkPreference>(json)
                    );
                builder.HasKey(p => p.PreferenceId);
            });

        }

    }

}