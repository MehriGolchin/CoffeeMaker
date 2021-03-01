using System.Collections.Generic;
using System.Threading.Tasks;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Service {

    public interface IDrinkService {

        Task<IEnumerable<DrinkDto>> GetAllDrinksAsync();
        Task<IEnumerable<DrinkIngredientDto>> GetDrinkIngredientByIdAsync(int drinkId);
    }

}