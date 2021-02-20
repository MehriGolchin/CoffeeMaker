using System.Threading.Tasks;

namespace CafeeMaker.Domain.Entities {

    public interface IEmployeeRepository {

        ValueTask<Employee> GetEmployeeByIdAsync(int employeeId);

    }

}