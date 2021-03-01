using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Service;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Application {

    public class EmployeeService : IEmployeeService {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId) {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null) return null;
            return new EmployeeDto {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }

    }

}