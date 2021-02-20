using System.Threading.Tasks;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Infrastructure.Repositories {

    public class EmployeeRepository : IEmployeeRepository {
        
        private readonly CafeeMakerDbContext _context;

        public EmployeeRepository(CafeeMakerDbContext context) {
            _context = context;
        }

        public async ValueTask<Employee> GetEmployeeByIdAsync(int employeeId) {
            return await _context.Employees.FindAsync(employeeId);
        }

    }

}