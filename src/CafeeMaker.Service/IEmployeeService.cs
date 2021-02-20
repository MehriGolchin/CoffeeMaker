using System.Threading.Tasks;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Service {

    public interface IEmployeeService {

        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);

    }

}