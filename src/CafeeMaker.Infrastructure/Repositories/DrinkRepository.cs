using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeeMaker.Infrastructure.Repositories {

    public class DrinkRepository : IDrinkRepository {

        private readonly CafeeMakerDbContext _dbContext;

        public DrinkRepository(CafeeMakerDbContext dbContext) {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Drink>> GetAllDrinksAsync() {
            return await _dbContext.Drinks.ToListAsync();
        }

        public async Task<IEnumerable<DrinkIngredient>> GetDrinkIngredientByIdAsync(int drinkId) {
            return await _dbContext.DrinkIngredients
                .Include(di => di.Ingredient)
                .Where(di => di.DrinkId == drinkId)
                .ToListAsync();

            // var query = (from di in _dbContext.DrinkIngredients
            //         join i in _dbContext.Ingredient on di.IngredientId equals i.IngredientId
            //     where di.DrinkId == drinkId
            //         select new {di.IngredientId, i.Name});
            // return await query.ToListAsync();
        }

    }

}