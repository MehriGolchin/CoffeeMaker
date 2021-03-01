using System.Collections.Generic;
using System.Threading.Tasks;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Domain {

    public interface IDrinkRepository {

        Task<IEnumerable<Drink>> GetAllDrinksAsync();
        Task<IEnumerable<DrinkIngredient>> GetDrinkIngredientByIdAsync(int drinkId);

    }

}