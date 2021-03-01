using System.Security.Claims;
using System.Threading.Tasks;
using CafeeMaker.Service;
using CafeeMaker.Web.Models;
using CafeeMaker.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeeMaker.Web.Controllers {

    [Route("/[action]")]
    public class LoginController : Controller {

        private readonly ILoginService _loginService;
        private readonly IEmployeeService _employeeService;

        public LoginController(ILoginService loginService,
            IEmployeeService employeeService) {
            _loginService = loginService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (!ModelState.IsValid) {
                return View();
            }
            
            var employee = await _employeeService.GetEmployeeByIdAsync(model.EmployeeId);
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