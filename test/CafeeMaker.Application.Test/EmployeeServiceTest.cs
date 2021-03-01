using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Domain.Entities;
using NSubstitute;
using Xunit;

namespace CafeeMaker.Application.Test {

    public class EmployeeServiceTest {

        [Fact]
        public async Task GetEmployeeByIdAsync_should_return_employee_when_employee_exists() {
            // Arrange
            const int employeeId = 123;

            var employee = new Employee(employeeId, "a", "b");

            var repository = Substitute.For<IEmployeeRepository>();
            repository.GetEmployeeByIdAsync(employeeId).Returns(ValueTask.FromResult(employee));

            var service = new EmployeeService(repository);

            // Act
            var result = await service.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.Equal(employee.EmployeeId, result.EmployeeId);
            Assert.Equal(employee.FirstName, result.FirstName);
            Assert.Equal(employee.LastName, result.LastName);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_should_return_null_when_employee_not_exist() {
            // Arrange
            const int employeeId = 123;

            var repository = Substitute.For<IEmployeeRepository>();
            repository.GetEmployeeByIdAsync(employeeId).Returns(ValueTask.FromResult<Employee>(null));

            var service = new EmployeeService(repository);

            // Act
            var result = await service.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.Null(result);
        }

    }

}