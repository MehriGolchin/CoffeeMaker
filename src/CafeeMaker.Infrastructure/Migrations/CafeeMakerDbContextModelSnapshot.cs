﻿// <auto-generated />
using CafeeMaker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CafeeMaker.Infrastructure.Migrations
{
    [DbContext(typeof(CafeeMakerDbContext))]
    partial class CafeeMakerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CafeeMaker.Domain.Entities.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("drink_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("drink_image");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("drink_name");

                    b.HasKey("DrinkId");

                    b.ToTable("drink");

                    b.HasData(
                        new
                        {
                            DrinkId = 1,
                            Image = "/img/tea1.png",
                            Name = "Thé"
                        },
                        new
                        {
                            DrinkId = 2,
                            Image = "/img/coffee1.png",
                            Name = "Café"
                        },
                        new
                        {
                            DrinkId = 3,
                            Image = "/img/chocolate1.png",
                            Name = "Chocolat"
                        });
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.DrinkIngredient", b =>
                {
                    b.Property<int>("DrinkIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("drink_ingredient_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer")
                        .HasColumnName("drink_id");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id");

                    b.HasKey("DrinkIngredientId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("IngredientId");

                    b.ToTable("drink_ingredient");

                    b.HasData(
                        new
                        {
                            DrinkIngredientId = 1,
                            Amount = 100,
                            DrinkId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            DrinkIngredientId = 2,
                            Amount = 100,
                            DrinkId = 1,
                            IngredientId = 2
                        },
                        new
                        {
                            DrinkIngredientId = 3,
                            Amount = 50,
                            DrinkId = 1,
                            IngredientId = 3
                        },
                        new
                        {
                            DrinkIngredientId = 4,
                            Amount = 50,
                            DrinkId = 2,
                            IngredientId = 7
                        },
                        new
                        {
                            DrinkIngredientId = 5,
                            Amount = 50,
                            DrinkId = 2,
                            IngredientId = 4
                        },
                        new
                        {
                            DrinkIngredientId = 6,
                            Amount = 20,
                            DrinkId = 2,
                            IngredientId = 1
                        },
                        new
                        {
                            DrinkIngredientId = 7,
                            Amount = 40,
                            DrinkId = 2,
                            IngredientId = 3
                        },
                        new
                        {
                            DrinkIngredientId = 8,
                            Amount = 100,
                            DrinkId = 3,
                            IngredientId = 5
                        },
                        new
                        {
                            DrinkIngredientId = 9,
                            Amount = 100,
                            DrinkId = 3,
                            IngredientId = 8
                        },
                        new
                        {
                            DrinkIngredientId = 10,
                            Amount = 30,
                            DrinkId = 3,
                            IngredientId = 3
                        });
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("employee_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.HasKey("EmployeeId");

                    b.ToTable("employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 100,
                            FirstName = "AA1",
                            LastName = "BB1"
                        },
                        new
                        {
                            EmployeeId = 200,
                            FirstName = "AA2",
                            LastName = "BB2"
                        });
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("ingredient_name");

                    b.HasKey("IngredientId");

                    b.ToTable("ingredient");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "Eau chaude"
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "Thé noir"
                        },
                        new
                        {
                            IngredientId = 3,
                            Name = "Sucre"
                        },
                        new
                        {
                            IngredientId = 4,
                            Name = "Lait"
                        },
                        new
                        {
                            IngredientId = 5,
                            Name = "Crème fouettée"
                        },
                        new
                        {
                            IngredientId = 6,
                            Name = "Eau froide"
                        },
                        new
                        {
                            IngredientId = 7,
                            Name = "Café"
                        },
                        new
                        {
                            IngredientId = 8,
                            Name = "Chocolat"
                        });
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.Preference", b =>
                {
                    b.Property<int>("PreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("preference_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer")
                        .HasColumnName("drink_id");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("PreferenceId");

                    b.ToTable("preference");
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.DrinkIngredient", b =>
                {
                    b.HasOne("CafeeMaker.Domain.Entities.Drink", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeeMaker.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("CafeeMaker.Domain.Entities.Drink", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
