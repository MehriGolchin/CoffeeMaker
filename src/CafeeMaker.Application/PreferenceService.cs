using System.Linq;
using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Domain.Entities;
using CafeeMaker.Service;
using CafeeMaker.Service.Dtos;

namespace CafeeMaker.Application {

    public class PreferenceService : IPreferenceService {

        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceService(IPreferenceRepository preferenceRepository) {
            _preferenceRepository = preferenceRepository;
        }

        public async Task SavePreferenceAsync(PreferenceDto preference) {
            var previousPreference = await _preferenceRepository.GetPreferenceAsync(preference.EmployeeId, preference.DrinkId);

            await _preferenceRepository.SavePreferenceAsync(
                Preference.Create(
                    preference.EmployeeId,
                    preference.DrinkId,
                    new DrinkPreference(
                        preference.Amounts.Select(a => new IngredientAmount(a.DrinkIngredientId, a.Amount)),
                        preference.Mug
                    ),
                    preferenceId: previousPreference?.PreferenceId ?? 0));
        }

        public async Task<PreferenceDto> GetPreferenceAsync(int employeeId, int drinkId) {
            var preference = await _preferenceRepository.GetPreferenceAsync(employeeId, drinkId);
            if (preference is null) return null;
            return new PreferenceDto {
                EmployeeId = preference.EmployeeId,
                DrinkId = preference.DrinkId,
                Amounts = preference.Value.Amounts.Select(a => new IngredientAmountEntry
                    {DrinkIngredientId = a.DrinkIngredientId, Amount = a.Amount}),
                Mug = preference.Value.Mug
            };
        }

    }

}