using System.Threading.Tasks;
using CafeeMaker.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase {

        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService) {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrinks() {
            var drinks = await _drinkService.GetAllDrinksAsync();
            return Ok(drinks);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDrinkIngredientByIdAsync(int id) {
            var drinkIngredients = await _drinkService.GetDrinkIngredientByIdAsync(id);
            return Ok(drinkIngredients);
        }

    }

}