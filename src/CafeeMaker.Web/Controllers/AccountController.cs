using System.Security.Claims;
using System.Threading.Tasks;
using CafeeMaker.Service;
using CafeeMaker.Web.Models;
using CafeeMaker.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    [Route("/[controller]")]
    public class AccountController : Controller {

        private readonly ILoginService _loginService;
        private readonly IEmployeeService _employeeService;

        public AccountController(ILoginService loginService,
            IEmployeeService employeeService) {
            _loginService = loginService;
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromQuery] string returnUrl) {
            return View(new LoginViewModel {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            
            var employee = await _employeeService.GetEmployeeByIdAsync(model.EmployeeId.GetValueOrDefault());
            if (employee == null) {
                ModelState.AddModelError(nameof(model.EmployeeId), "Badge number does not exist.");
                return View(model);
            }
            
            await _loginService.SignInAsync(new[] {
                new Claim("id", employee.EmployeeId.ToString()),
            });
            
            return Redirect(model.ReturnUrl ?? "/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await _loginService.SignOutAsync();
            return RedirectToAction("Login");
        }

    }

}