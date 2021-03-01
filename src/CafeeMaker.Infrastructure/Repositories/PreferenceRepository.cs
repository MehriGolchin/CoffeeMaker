using System;
using System.Linq;
using System.Threading.Tasks;
using CafeeMaker.Domain;
using CafeeMaker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeeMaker.Infrastructure.Repositories {

    public class PreferenceRepository: IPreferenceRepository {
        
        private readonly CafeeMakerDbContext _dbContext;

        public PreferenceRepository(CafeeMakerDbContext dbContext) {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task SavePreferenceAsync(Preference preference) {
            if (preference.PreferenceId != 0) {
                _dbContext.Entry(preference).State = EntityState.Modified;
                _dbContext.Preferences.Update(preference);
            } else {
                await _dbContext.Preferences.AddAsync(preference);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Preference> GetPreferenceAsync(int employeeId, int drinkId) {
            return await _dbContext.Preferences
                .Where(p => p.EmployeeId == employeeId && p.DrinkId == drinkId)
                .FirstOrDefaultAsync();
        }

    }

}