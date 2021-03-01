using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Service;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Application {

    public class DrinkService : IDrinkService {
        
        private readonly IDrinkRepository _drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository) {
            _drinkRepository = drinkRepository;
        }

        public async Task<IEnumerable<DrinkDto>> GetAllDrinksAsync() {
            var drinks = await _drinkRepository.GetAllDrinksAsync();
            var drinkList = drinks.Select(d => new DrinkDto() {
                    DrinkId = d.DrinkId,
                    Name = d.Name,
                    Image = d.Image
                }).OrderBy(d => d.Name)
                .ToList();
            return drinkList;
        }

        public async Task<IEnumerable<DrinkIngredientDto>> GetDrinkIngredientByIdAsync(int drinkId) {
            var drinkIngredients = await _drinkRepository.GetDrinkIngredientByIdAsync(drinkId);
            var drinkIngredientList = drinkIngredients.Select(d => new DrinkIngredientDto() {
                Ingredient = d.Ingredient,
                Amount = d.Amount,
                DrinkId = d.DrinkId,
                DrinkIngredientId = d.DrinkIngredientId,
                IngredientId = d.IngredientId
            }).ToList();
            return drinkIngredientList;
        }

    }

}