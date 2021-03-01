using System.Threading.Tasks;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Domain {

    public interface IEmployeeRepository {

        ValueTask<Employee> GetEmployeeByIdAsync(int employeeId);

    }

}