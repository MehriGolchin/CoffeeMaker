namespace CafeeMaker.Domain.Entities {

    public class Employee {

        public Employee(int employeeId, string firstName, string lastName) {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public int EmployeeId { get; }
        public string FirstName { get; }
        public string LastName { get; }

    }

}