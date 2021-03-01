using System.Threading.Tasks;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Domain {

    public interface IPreferenceRepository {

        Task SavePreferenceAsync(Preference preference);
        Task<Preference> GetPreferenceAsync(int employeeId, int drinkId);

    }

}