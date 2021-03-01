using System.Security.Claims;
using System.Threading.Tasks;
using CafeeMaker.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    public class PreferenceController : ControllerBase {
        
        private readonly IPreferenceService _preferenceService;
        
        public PreferenceController(IPreferenceService preferenceService) {
            _preferenceService = preferenceService;
        }

        [HttpGet]
        [Route("{drinkId}")]
        public async Task<IActionResult> GetPreference(int drinkId) {
            var employeeId = int.Parse(User.FindFirstValue("id"));

            var preference = await _preferenceService.GetPreferenceAsync(employeeId, drinkId);
            return Ok(preference);
        }

    }

}