using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CafeeMaker.Infrastructure;
using CafeeMaker.Service;
using CafeeMaker.Service.Dtos;
using CafeeMaker.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase {

        private readonly IPreferenceService _preferenceService;
        private readonly IDrinkService _drinkService;
        private readonly ICoffeeMachine _coffeeMachine;
        
        public OrderController(IPreferenceService preferenceService, ICoffeeMachine coffeeMachine, IDrinkService drinkService) {
            _preferenceService = preferenceService;
            _coffeeMachine = coffeeMachine;
            _drinkService = drinkService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequest request) {
            var employeeId = int.Parse(User.FindFirstValue("id"));

            var ingredients = await _drinkService.GetDrinkIngredientByIdAsync(request.DrinkId);
            var drinkRequest = new DrinkRequest(
                ingredients.Select(i => new DrinkRequest.Ingredient(
                    i.Ingredient.Name,
                    request.GetIngredientAmountOrDefault(i.DrinkIngredientId, i.Amount)
                )),
                request.Mug
            );
            
            await _coffeeMachine.MakeDrink(drinkRequest);
            
            await _preferenceService.SavePreferenceAsync(new PreferenceDto {
                EmployeeId = employeeId,
                DrinkId = request.DrinkId,
                Amounts = request.Amounts,
                Mug = request.Mug
            });

            return Ok(true);
        }

    }

}