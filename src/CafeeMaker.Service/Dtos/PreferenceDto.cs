using System.Collections.Generic;
using CafeeMaker.Domain.Entities;

namespace CafeeMaker.Service.Dtos {

    public class PreferenceDto {
        
        public int EmployeeId { get; set; }
        public int DrinkId { get; set; }
        public IEnumerable<IngredientAmountEntry> Amounts { get; set; }
        public Mug Mug { get; set; }

    }

}