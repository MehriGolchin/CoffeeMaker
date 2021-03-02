using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CafeeMaker.Service;
using CafeeMaker.Service.Dtos;
using CafeeMaker.Web.Controllers;
using CafeeMaker.Web.Models;
using CafeeMaker.Web.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace CafeeMaker.Web.Test.Controllers {
    
    public class LoginControllerTest {

        [Fact]
        public async Task Should_login_user_when_employee_id_is_correct() {
            // Arrange
            const int employeeId = 123;

            var loginService = Substitute.For<ILoginService>();

            var employeeService = Substitute.For<IEmployeeService>();
            employeeService.GetEmployeeByIdAsync(employeeId).Returns(Task.FromResult<EmployeeDto>(new EmployeeDto() {
                EmployeeId = employeeId,
                FirstName = "a",
                LastName = "b"
            }));

            const string redirectUrl = "/somewhere";

            var controller = new AccountController(loginService, employeeService);

            // Act
            var result = await controller.Login(new LoginViewModel {EmployeeId = employeeId, ReturnUrl = redirectUrl});

            // Assert
            await loginService.Received().SignInAsync(Arg.Any<IEnumerable<Claim>>());
            var res = Assert.IsType<RedirectResult>(result);
            Assert.Equal(redirectUrl, res.Url);
        }

        [Fact]
        public async Task Should_return_login_view_when_employee_id_is_incorrect() {
            // Arrange
            const int employeeId = 123;

            var loginService = Substitute.For<ILoginService>();

            var employeeService = Substitute.For<IEmployeeService>();
            employeeService.GetEmployeeByIdAsync(employeeId).Returns(Task.FromResult<EmployeeDto>(null));

            var controller = new AccountController(loginService, employeeService);

            // Act
            var result = await controller.Login(new LoginViewModel {EmployeeId = employeeId});

            // Assert
            await loginService.DidNotReceive().SignInAsync(Arg.Any<IEnumerable<Claim>>());
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Should_return_login_view_when_employee_id_is_empty() {
            // Arrange
            var loginService = Substitute.For<ILoginService>();
            var employeeService = Substitute.For<IEmployeeService>();

            var controller = new AccountController(loginService, employeeService);
            controller.ModelState.AddModelError("EmployeeId", "The employee id is required.");

            // Act
            var result = await controller.Login(new LoginViewModel());

            // Assert
            await loginService.DidNotReceive().SignInAsync(Arg.Any<IEnumerable<Claim>>());
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Should_logout_employee() {
            // Arrange
            var loginService = Substitute.For<ILoginService>();
            var employeeService = Substitute.For<IEmployeeService>();

            var controller = new AccountController(loginService, employeeService);

            // Act
            var result = await controller.Logout();

            // Assert
            await loginService.Received().SignOutAsync();
            Assert.IsType<RedirectToActionResult>(result);
        }

    }

}