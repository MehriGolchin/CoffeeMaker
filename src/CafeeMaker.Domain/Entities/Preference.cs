namespace CafeeMaker.Domain.Entities {

    public class Preference {

        private Preference() {
        }

        public Preference(int preferenceId, int employeeId, int drinkId, DrinkPreference value) {
            PreferenceId = preferenceId;
            EmployeeId = employeeId;
            DrinkId = drinkId;
            Value = value;
        }
        
        public int PreferenceId { get; private set; }
        public int EmployeeId { get; private set; }
        public int DrinkId { get; private set; }
        public DrinkPreference Value { get; private set; }

        public static Preference Create(int employeeId, int drinkId, DrinkPreference value, int preferenceId = 0) {
            return new Preference {
                PreferenceId = preferenceId,
                EmployeeId = employeeId,
                DrinkId = drinkId,
                Value = value
            };
        }

    }

}