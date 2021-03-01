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
        private readonly ICoffeeMachine _coffeeMachine;
        
        public OrderController(IPreferenceService preferenceService, ICoffeeMachine coffeeMachine) {
            _preferenceService = preferenceService;
            _coffeeMachine = coffeeMachine;
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequest request) {
            var employeeId = int.Parse(User.FindFirstValue("id"));

            await _coffeeMachine.MakeDrink(new DrinkRequest(new DrinkRequest.Ingredient[0], request.Mug));
            
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