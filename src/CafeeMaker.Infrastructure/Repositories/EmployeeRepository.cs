using System;
using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Infrastructure.Repositories {

    public class EmployeeRepository : IEmployeeRepository {
        
        private readonly CafeeMakerDbContext _dbContext;

        public EmployeeRepository(CafeeMakerDbContext dbContext) {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async ValueTask<Employee> GetEmployeeByIdAsync(int employeeId) {
            return await _dbContext.Employees.FindAsync(employeeId);
        }

    }

}