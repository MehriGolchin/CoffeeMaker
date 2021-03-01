using System.Threading.Tasks;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Service {

    public interface IPreferenceService {

        Task SavePreferenceAsync(PreferenceDto preference);
        Task<PreferenceDto> GetPreferenceAsync(int employeeId, int drinkId);

    }

}